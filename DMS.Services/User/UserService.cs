using DMS.Utility.Library;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using DMS.Core.Dto;
using DMS.Core.Dto.User;
using DMS.Core.Models.SystemManager;
using DMS.Data;
using DMS.Services.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using DMS.Core.DTO.User;

namespace DMS.Services
{
    public class UserService : IUserService
    {
        public IConfiguration Config { get; }


        private readonly DbContext context;
        private readonly UserRepository repo;
        public string Token { get; set; } 

        public UserService(IConfiguration configuration)
        {
            this.Config = configuration;
            this.context = new SystemManagerContext(this.Config);
            this.repo = new UserRepository(this.context);
        }

        public async Task<UserBasicInfo> IsAuthenticated(LoginRequestDto request)
        {
            this.Token = string.Empty;
            string credDetail = new JSONSerialize().getJSONString(request);
            DMS.Utility.Library.Scripting.writeFile(ref credDetail, @"D:\WEB SERVER\Log\credDetail.ini");


            // 
            request.EmployeeID = request.EmployeeID.ToUpper();
            request.Password = DataSecurity.getMD5Hash(request.Password);



            if (string.IsNullOrEmpty(request.EmployeeID)) throw new Exception("Employeeid is required");
            if (string.IsNullOrEmpty(request.Password)) throw new Exception("Password is required");
            //



            string usercred = "IsAuthenticated :: " +  new JSONSerialize().getJSONString(request);
            DMS.Utility.Library.Scripting.writeFile(ref usercred, @"D:\WEB SERVER\Log\usercred.ini");
            

            var validatedUser = await isValidUserCredentials(request);
            if (validatedUser == null) throw new Exception("Invalid employeeid or password");
            



            var permClaims = new List<Claim>();
            //permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            permClaims.Add(new Claim("user", new JSONSerialize().getJSONString(validatedUser)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Config["TokenManagement:Secret"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(
                Config["TokenManagement:Issuer"],
                Config["TokenManagement:Audience"],
                permClaims,
                expires: DateTime.Now.AddMinutes(int.Parse( Config["TokenManagement:AccessExpiration"])),
                signingCredentials: credentials
            );
            
            this.Token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            

            return validatedUser;
        }

        public async Task<UserBasicInfo> isValidUserCredentials(LoginRequestDto request)
        {
            var userInfo = await repo.validateUser(request.EmployeeID, request.Password);
            if (userInfo != null && userInfo.FirstOrDefault().EmployeeID == request.EmployeeID) return userInfo.FirstOrDefault();
            else return null;
        }

        public async Task<UserBasicInfo> getUserDetail(string EmployeeID)
        {
            var data = await repo.getUserDetail(EmployeeID);
            return data.FirstOrDefault();
        }

        public async Task<UserAccount> getUserCredentialInfo(string EmployeeID)
        {
            var userDetail = await repo.getUserAccount(EmployeeID);
            return userDetail;
        }

        public async Task<Boolean> updateUserPassword(LoginRequestDto request)
        {
            request.Password = DataSecurity.getMD5Hash(new JSONSerialize().DecodeBase64(request.Password));

            var userDetail = await repo.getUserAccount(request.EmployeeID);

            if (userDetail != null)
            {
                userDetail.Password = request.Password;
                userDetail.PasswordInPlainText = request.PasswordInPlainText;
                await repo.updateUserAccount(userDetail.Id, userDetail);
                return true;
            }

            return false;
        }
        public async Task<Location> getCurrentLocation()
        {
            return await repo.getCurrentLocation();
        }

        //user permission master detail

        // GET 

        public async Task<List<PrivilegedMenuDto>> getDMSUserPrivilegedMenuList(string EmployeeCode)
        {
            
            var data = await repo.getDMSUserPrivilegedMenu(EmployeeCode);

            List<PrivilegedMenuDto> privilegedMenus = new List<PrivilegedMenuDto>();
            List<DMSUserPrivilegedMenuDto> modules = data.Where(m=> m.Route=="#" || m.ModuleID==null ).ToList<DMSUserPrivilegedMenuDto>();

            foreach (DMSUserPrivilegedMenuDto item in modules)
            {
                PrivilegedMenuDto rpt = new PrivilegedMenuDto();
                rpt.ModuleID = item.MenuID;
                rpt.ModuleName = item.MenuName;

                rpt.SubMenus = new List<DMSUserPrivilegedMenuDto>();

                var subMenus = data.Where(m => m.ModuleID == item.MenuID).ToList();
                if(!subMenus.Any()) continue;

                rpt.SubMenus.AddRange(subMenus);

                privilegedMenus.Add(rpt);
            }

            return privilegedMenus;
               
        }


    }
}
