using DMS.Core.DTO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMS.Data.Repository
{
    // ============================================= 
    // Author:	<Md.Mehedi Hasan>
    // Email:	<mehedi.sun @gmail.com>
    // Created on: <30-Jan-2022><Updated on: 30-Jan-2022>
    // Last updated on: <>
    // Description:	<>
    // ============================================= 

    public class LocationRepository
    {
    
        private DbContext context = null;

        public LocationRepository(DbContext context)
        {
            this.context = context;
           this.context.Database.SetCommandTimeout(240);

        }


        public async Task<List<TerritoryDTO>> GetAllTerritory(string areacode)
        {
            return await this.context.Set<TerritoryDTO>().FromSqlRaw("exec GetAllTerritory @AreaCode"
                , new SqlParameter("@AreaCode", areacode)).ToListAsync();

        }
       
    }
}
