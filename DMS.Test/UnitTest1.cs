using DMS.Controllers;
using DMS.Core.DTO.SalesOrder;
using DMS.Services.Interfaces;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Xunit;

namespace DMS.Test
{
    public class UnitTest1
    {
        [Fact]
        public async void Test1()
        {

            var dataStore = A.Fake<IProductService>();
            var controller = new ProductController(dataStore);

            var actionResult =  controller.getProducts();

            var result = actionResult.Result as OkObjectResult;
            
            var products = result.Value as List<ProductsDto>;

            Assert.NotNull(products);
        }
    }
}
