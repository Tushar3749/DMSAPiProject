
/*
 *=============================================
 *Author: Shamsul Hasan Siam
 *Email: siam.it@labaidpharma.com
 *Created on: 7 june 2020
 *Updated on: 
 *Last updated on:
 *Description: <>
 *=============================================
*/



using AutoMapper;
using DMS.Core.DTO.Orders;
using DMS.Core.Models.SalesInvoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Services.Map
{
    public class OrderMap
    {
		public Order map(OrdersDto source)
		{
			var config = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<OrdersDto, Order>();
			});

			return config.CreateMapper().Map<OrdersDto, Order>(source);
		}

	}
}
