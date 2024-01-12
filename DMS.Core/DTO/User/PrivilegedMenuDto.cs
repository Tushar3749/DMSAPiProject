using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;


namespace DMS.Core.DTO.User
{
    [Keyless]
    public class PrivilegedMenuDto
    {
     
        public int? MenuID { get; set; }
        public int? ModuleID { get; set; }
        public string? ModuleName { get; set; }

        public string Route { get; set; }
        
        public Nullable<Boolean> ShowingStatus { get; set; }
        public Nullable<Boolean> HasView { get; set; }

        public Nullable<Boolean> HasInsert { get; set; }
        public Nullable<Boolean> HasUpdate { get; set; }
        public Nullable<Boolean> HasDelete { get; set; }
        public Nullable<Boolean> HasPrint { get; set; }
        public Nullable<Boolean> HasFullAccess { get; set; }

        public Nullable<Boolean> HasApprove { get; set; }

       
        public List<DMSUserPrivilegedMenuDto> SubMenus { get; set; }
    }


    
}
