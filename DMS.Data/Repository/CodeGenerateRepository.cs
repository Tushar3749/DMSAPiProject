using DMS.Core.DTO;
using DMS.Core.Models.SalesInvoice;
using DMS.Data.Repositories.GenericRepository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Data.Repository
{
    public class CodeGenerateRepository
    {
        private DbContext context = null;


        public CodeGenerateRepository(DbContext context)
        {
            this.context = context;
        }

        public async Task<string> getGeneratedCode(string ModuleName)
        {
            var code = await this.context.Set<GeneratedCode>().FromSqlRaw("exec generateCodeForModule @ModuleName",
            new SqlParameter("@ModuleName", ModuleName)).ToListAsync();

            return code.FirstOrDefault().Code;
        }

    }
}
