using DMS.Core.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Core.DTO.Security
{
    public class ExceptionGroup
    {

        public static string Allocation = "Allocation";
        public static string Invoice = "Invoice";
        public static string SalesOrder = "SalesOrder";



        public static ErrorMessageDto setMessage(string ModuleType, string ErrorNumber,  string Message)
        {
            try
            {
                return new ErrorMessageDto { Code = ExceptionGroup.Allocation + "- " + ErrorNumber, Title = ModuleType, Details = Message };
            }
            catch { return new ErrorMessageDto { Code = ModuleType, Title = ModuleType, Details = Message }; }
        }
    }
}
