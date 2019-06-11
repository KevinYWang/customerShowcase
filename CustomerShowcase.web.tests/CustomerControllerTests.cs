using System;
using System.Collections.Generic;
using System.IO;
using CustomerShowcase.common.Model;
using CustomerShowcase.common.Services;
using CustomerShowcase.web.Controllers;
using GemBox.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Xunit;

namespace CustomerShowcase.web.tests
{
    public class CustomerControllerTests
    {
        private CustomerController customerController;

        public CustomerControllerTests()
        {
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");

            var normalFilePath = Path.GetFullPath("./TestData/SampleData.csv");
            var customerDataService = new CustomerDataService(normalFilePath);
            customerController = new CustomerController(customerDataService);
        }


        [Fact]
        public void GetCustomerListBySearchingStringTestWithoutQueryString()
        {
            Assert.NotNull(customerController);

            var results = customerController.GetCustomerListBySearchingString(string.Empty, 1, 50);
            Assert.IsType<JsonResult>(results);
        }

        [Fact]
        public void GetCustomerListBySearchingStringTestWithQueryString()
        { 
            var searchStr = "rtabar@hotmail";
            JsonResult results = (JsonResult)customerController.GetCustomerListBySearchingString(searchStr,1,50);

            var innerData = results.Value.ToString();
            Assert.True(!string.IsNullOrEmpty(innerData));
        }
    }
}