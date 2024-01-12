using DMS.Core.Models.Maintenance;
using DMS.Data.Repository;
using DMS.Services.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace DMS.Services
{
    public class BugReportingService: SessionService
    {

        private readonly BugReportingRepository repo = null;
        private readonly DbContext context;



        public BugReportingService(IConfiguration Config)
        {
            this.context = new MaintenanceContext(Config);
            this.repo = new BugReportingRepository(this.context);
        }


     


		public async Task<ErrorLog> sendBugReport(Exception Error,string Title="", string FunctionName = "")
		{
			try
			{
				ErrorLog log = new ErrorLog();


				log.DepotCode = "NA";
				log.ExceptionDetails = LoggerService.getAllErrorString(Error);
				if(_SESSION_USER!=null) log.DepotCode = _SESSION_USER.DepotCode;
				log.ExceptionTitle = Title + ";" + FunctionName;
				if (_SESSION_USER != null) log.ReportedById = _SESSION_USER.EmployeeID;

				return await repo.saveErrorLogs(log);
			}
			catch (Exception ex) { return null; }
		}

	}
}
