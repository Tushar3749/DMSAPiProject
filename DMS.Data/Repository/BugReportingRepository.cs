using DMS.Core.Models.Maintenance;
using DMS.Data.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DMS.Data.Repository
{
    public class BugReportingRepository
    {
        private GenericRepository<ErrorLog> salesOrder = null;
        private DbContext context = null;

        public BugReportingRepository(DbContext context)
        {
            this.context = context;
            this.salesOrder = new GenericRepository<ErrorLog>(context);
        }


        // SAVE
        public async Task<ErrorLog> saveErrorLogs(ErrorLog Entity)
        {
            Entity.CreatedOn = DateTime.Now;
            return await new GenericRepository<ErrorLog>(this.context).Insert(Entity);
        }


    }
}
