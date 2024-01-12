using Microsoft.EntityFrameworkCore;
using System;

namespace DMS.Core.DTO
{
	[Keyless]
    public class InvoiceReturnTypeDto 
	{
		public Nullable<int> ID { get; set; }

		public string Code { get; set; }
		public string TypeName { get; set; }
	}

}
