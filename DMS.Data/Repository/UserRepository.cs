using DMS.Core.Dto.User;
using DMS.Core.Models.SystemManager;
using DMS.Data.Repositories.GenericRepository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using DMS.Core.DTO.User;

namespace DMS.Data
{
    public class UserRepository 
    {
        private GenericRepository<UserAccount> user = null;
        private DbContext context = null;

        public UserRepository(DbContext context)
        {
            this.context = context;
            this.user = new GenericRepository<UserAccount>(context);
        }


        public async Task<IEnumerable<UserBasicInfo>> validateUser(string EmployeeID, string Password)
        {
            var result = await this.context.Set<UserBasicInfo>().FromSqlRaw("exec validateUser @EmployeeID, @Password",
                new SqlParameter("@EmployeeID", EmployeeID), new SqlParameter("@Password", Password)).ToListAsync();

            return result;
        }

        public async Task<IEnumerable<UserBasicInfo>> getUserDetail(string EmployeeID)
        {
            var result = await this.context.Set<UserBasicInfo>().FromSqlRaw("exec getUserDetail @EmployeeID",
                new SqlParameter("@EmployeeID", EmployeeID)).ToListAsync();

            return result;
        }

        // Find One
        public async Task<UserAccount> getUserAccount(string EmployeeID)
        {
            var data = await new GenericRepository<UserAccount>(this.context).FindOne(U => U.EmployeeCode == EmployeeID);
            return data;
        }


        // UPDATE
        public async Task<UserAccount> updateUserAccount(int ID, UserAccount Entity)
        {
            Entity.UpdatedOn = DateTime.Now;
            return await new GenericRepository<UserAccount>(this.context).Update(Entity, U => U.Id == ID);
        }

        public async Task<Location> getCurrentLocation()
        {
            return await new GenericRepository<Location>(this.context).FindOne(i => i.IsCurrent == true);
        }

        //GET PREVEILIGE LIST 
        public async Task<List<DMSUserPrivilegedMenuDto>> getDMSUserPrivilegedMenu(string EmployeeCode)
        {
           var result = await this.context.Set<DMSUserPrivilegedMenuDto>().FromSqlRaw("getDMSUserPrivilegedMenu @EmployeeCode",
                new SqlParameter("@EmployeeCode", EmployeeCode)).ToListAsync();
            return result;
            
        }


    }
}
