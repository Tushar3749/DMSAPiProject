using DMS.Core.Models.Inventory;
using DMS.Data.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Data.Repository
{
   public class StockReceiveDetailsRepository :Repository
    {
        private GenericRepository<StockReceiveDetail> repo = null;
        private DbContext context = null;

        public StockReceiveDetailsRepository(DbContext context) : base(context)
        {
            this.context = context;
            this.repo = new GenericRepository<StockReceiveDetail>(this.context);
        }
    }
}
