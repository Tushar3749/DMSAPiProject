using DMS.Core.Models.HRMS;
using DMS.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DMS.Services.Employee
{
    public class EmployeeService: IEmployeeService
    {
        public IConfiguration Config { get; }


        private readonly DbContext context;


        public EmployeeService(IConfiguration configuration)
        {
            this.Config = configuration;
            this.context = new HRMSContext();
           
        }




	}
}
