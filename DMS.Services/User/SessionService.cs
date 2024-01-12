using DMS.Utility.Library;
using DMS.Core.Dto.User;
using System;
using System.Security.Principal;

namespace DMS.Services.User
{
    public class SessionService : LoggerService
    {
        public UserBasicInfo _SESSION_USER = null;

        public SessionService() : base()
        {

        }

        public SessionService(IPrincipal User)
        {
            try
            {
                this._SESSION_USER = new UserBasicInfo();
                var user = User;
                if (user == null) return;

                System.Security.Claims.ClaimsPrincipal claimUser = (System.Security.Claims.ClaimsPrincipal)User;
                if (claimUser == null) return;
                var item = claimUser.FindFirst("user");
                if (item != null) this._SESSION_USER = new JSONSerialize().getObjectFromJSONString<UserBasicInfo>(item.Value);

                if (_SESSION_USER == null || (_SESSION_USER != null && _SESSION_USER.EmployeeID == null)) throw new Exception("Invalid user details");
            }
            catch (Exception ex)
            {

            }
        }
    }
}
