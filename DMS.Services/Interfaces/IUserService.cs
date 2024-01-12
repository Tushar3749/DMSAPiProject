using DMS.Core.Dto;
using DMS.Core.Dto.User;
using DMS.Core.DTO.User;
using DMS.Core.Models.SystemManager;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMS.Services.Interfaces
{
    public interface IUserService
    {
        string Token { get; set; }
        Task<UserBasicInfo> IsAuthenticated(LoginRequestDto request);
        Task<UserBasicInfo> getUserDetail(string EmployeeID);
        Task<Boolean> updateUserPassword(LoginRequestDto request);

        Task<Location> getCurrentLocation();
        Task<List<PrivilegedMenuDto>> getDMSUserPrivilegedMenuList(string EmployeeCode);
        Task<UserAccount> getUserCredentialInfo(string EmployeeID);

    }
}
