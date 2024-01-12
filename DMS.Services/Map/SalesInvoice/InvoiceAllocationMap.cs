using AutoMapper;
using DMS.Core.DTO.SalesInvoice;
using DMS.Core.Models.SalesInvoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Services.Map.SalesInvoice
{
   public class InvoiceAllocationMap
    {
        // MAPPING 
        public InvoiceAllocation map(InvoiceAllocationDTO source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<InvoiceAllocationDTO, InvoiceAllocation>();
            });

            return config.CreateMapper().Map<InvoiceAllocationDTO, InvoiceAllocation>(source);
        }
    }
}
