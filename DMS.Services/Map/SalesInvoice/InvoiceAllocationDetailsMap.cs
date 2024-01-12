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
   public class InvoiceAllocationDetailsMap
    {
        // MAPPING 
        public InvoiceAllocationDetail map(InvoiceAllocationDetailsDTO source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<InvoiceAllocationDetailsDTO, InvoiceAllocationDetail>();
            });

            return config.CreateMapper().Map<InvoiceAllocationDetailsDTO, InvoiceAllocationDetail>(source);
        }
    }
}
