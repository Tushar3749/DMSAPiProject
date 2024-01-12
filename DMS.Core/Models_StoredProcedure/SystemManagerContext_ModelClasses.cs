using DMS.Core.Dto.User;
using DMS.Core.DTO;
using DMS.Core.DTO.Accounts;
using DMS.Core.DTO.SalesInvoice;
using DMS.Core.DTO.SummaryReturn;
using DMS.Core.DTO.User;
using DMS.Core.Models.SystemManager;
using Microsoft.EntityFrameworkCore;

namespace DMS.Core.Models_StoredProcedure
{
    public class SystemManagerContext_ModelClasses : DbContext
    {
        public SystemManagerContext_ModelClasses(): base()
        {

        }

        
        protected virtual DbSet<DMSUserPrivilegedMenuDto> DMSUserPrivilegedMenuDto { get; set; }
        protected virtual DbSet<UserBasicInfo> UserBasicInfo { get; set; }

        protected virtual DbSet<Location> Location { get; set; }



    }
}
