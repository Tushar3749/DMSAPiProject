using Microsoft.EntityFrameworkCore;
using DMS.Core.Models.HRMS;
using DMS.Data.Repositories.GenericRepository;
using System;
using System.Threading.Tasks;

namespace DMS.Data.Repository
{
    public class EmployeeUploadRepository
    {

        private GenericRepository<EmployeeUpload> employeeUpload = null;
        private DbContext context = null;

        public EmployeeUploadRepository(DbContext context)
        {
            this.context = context;
            this.employeeUpload = new GenericRepository<EmployeeUpload>(context);
        }

        public async Task<EmployeeUpload> getEmployeeUploads(string EmployeeID)
        {
            return await new GenericRepository<EmployeeUpload>(this.context).FindOne(E => E.EmployeeId == EmployeeID);
        }



        public async Task<EmployeeUpload> saveEmployeeUploads(EmployeeUpload Entity)
        {
            Entity.CreatedOn = DateTime.Now;
            return await new GenericRepository<EmployeeUpload>(this.context).Insert(Entity);
        }

        // UPDATE
        public async Task<EmployeeUpload> updateEmployeeUploads(int ID, EmployeeUpload Entity)
        {
            Entity.UpdatedOn = DateTime.Now;
            return await new GenericRepository<EmployeeUpload>(this.context).Update(Entity, E => E.Id == ID);
        }

    }
}
