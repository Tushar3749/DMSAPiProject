using DMS.Core.Models.Maintenance;
using NLog;
using System;
using System.IO;
using System.Threading.Tasks;

namespace DMS.Services
{
    public class LoggerService
    {

        public Exception error{ get; set; }

        


        public string getErrorMessages(Exception Error)
        {
            try
            {
                string ExceptionTitle = "";
                string ExceptionDetails = "";

                if (!string.IsNullOrEmpty(Error.Message)) ExceptionTitle = Error.Message;
                ExceptionDetails = getAllErrorString(Error);

                return ExceptionTitle + ", Details:  " + ExceptionDetails;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
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
        public void logException(Exception ex, string AdditionalMessage = "")
        {
            try
            {
                string error = ex.Message;
                if (string.IsNullOrEmpty(AdditionalMessage)) error += getAllErrorString(ex);
                else error += getAllErrorString(ex) + " Additional Message :" + AdditionalMessage;

                logException(error);
            }
            catch { }
            try
            {
                Logger logger = LogManager.GetLogger("customError");
                if (logger != null) logger.Error(getAllErrorString(ex));
            }
            catch { }
        }

        public void logException(string Message)
        {
            try
            {
                string filePath = @"D:\WEB SERVER\Log\DMS\";
                DMS.Utility.Library.Scripting.CheckAndCreateDir(filePath);
                Message = "\r\n" + DateTime.Now.ToString("hh:mm:ss :: ") + Message + "\r\n";
                DMS.Utility.Library.Scripting.writeFile(ref Message, Path.Combine(filePath, DateTime.Now.ToString("dd MMM yy") + ".ini"), true);
            }
            catch { }
            try
            {
                Logger logger = LogManager.GetLogger("customError");
                if (logger != null) logger.Error(Message);
            }
            catch { }
        }

        public void saveLog(string Message)
        {
            try
            {
                Logger logger = LogManager.GetLogger("customError");
                if (logger != null) logger.Error(Message);
            }
            catch { }
        }




    }
}
