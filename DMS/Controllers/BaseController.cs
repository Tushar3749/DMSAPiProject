using DMS.Core.Dto.User;
using DMS.Core.DTO.User;
using DMS.Services;
using DMS.Utility.Library;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System;
using System.Linq;

namespace DMS.Controllers
{

    public abstract class ControllerBase : Controller
    {
        protected UserBasicInfo getSessionUser()
        {
            string user = null;
            if (this.User == null || this.User.Claims == null || this.User.Claims.First() == null) return null; //throw new Exception("Invalid credentials");
            
            user = this.User.Claims.First().Value;
            if (user != null) return new JSONSerialize().getObjectFromJSONString<UserBasicInfo>(user);
            return null;
        }

     
        protected void saveLog(string Message)
        {
            try
            {
                Logger logger = LogManager.GetLogger("customError");
                if (logger != null) logger.Error(Message);
            }
            catch { }
        }


        protected ActionResult getResponse(object Data,  string Message= "")
        {
            ResponseDto response = new ResponseDto();
            response.Status = "OK";
            response.Message = Message;
            response.Data = Data;

            var result = new JSONSerialize().getJSONString(response, true);

            return Ok(result);
        }


        protected ActionResult getResponse(Exception ex)
        {
            ResponseDto response = new ResponseDto();
            response.Status = "ERROR";
            response.Message = getAllErrorString(ex);
            response.Data = null;

            // SAVE LOG
            try
            {
                saveLog(response.Message);
                new LoggerService().logException(response.Message);
            }
            catch { }

            return BadRequest(new JSONSerialize().getJSONString(response, true));
        }
        

        public static string getAllErrorString(Exception ex)
        {
            try
            {
                string Message = "";

                // Source
                if (!string.IsNullOrEmpty(ex.Source)) Message = "Source -> " + ex.Source + "\r\n";

                // Message
                if (!string.IsNullOrEmpty(ex.Message)) Message += ex.Message + "\r\n";

                if (ex.InnerException != null)
                {
                    var iEx = ex.InnerException;
                    if (!string.IsNullOrEmpty(iEx.Message))
                    {
                        if (!string.IsNullOrEmpty(iEx.Source)) Message += "Source -> " + iEx.Source + "\r\n";
                        Message += iEx.Message + "\r\n";
                    }
                }

                return Message;
            }
            catch { return ""; }
        }
    }
}
