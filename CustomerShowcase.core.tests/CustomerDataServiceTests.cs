using System;
using System.Collections.Generic;
using System.IO;
using CustomerShowcase.common.Model;
using CustomerShowcase.common.Services;
using GemBox.Spreadsheet;
using Xunit;

namespace CustomerShowcase.common.tests
{
    public class CustomerDataServiceTests
    {
        public CustomerDataServiceTests()
        {
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
        }

        [Fact]
        public void GetCustomerDataFromCsvFileTestWithNormalFile()
        {
            var filePath = Path.GetFullPath("./TestData/SampleData1.csv");
            var customerDataService = new CustomerDataService(filePath);

            var results = customerDataService.GetCustomerDataFromCsvFile(filePath);
            Assert.Equal(30, results.Count);
        }

        [Fact]
        public void GetCustomerDataFromCsvFileTestWithNoFile()
        {
            var normalFilePath = Path.GetFullPath("./TestData/SampleData.csv");
            var customerDataService = new CustomerDataService(normalFilePath);

            var wrongFilePath = Path.GetFullPath("./TestData/SampleDataNotExisting.csv");

            Assert.Throws<FileLoadException>(() => customerDataService.GetCustomerDataFromCsvFile(wrongFilePath));
        }

        [Fact]
        public void GetCustomerByQueryStringTests()
        {
            var normalFilePath = Path.GetFullPath("./TestData/SampleData.csv");
            var customerDataService = new CustomerDataService(normalFilePath);
            Assert.True(customerDataService.GetCustomerByQueryString(string.Empty).Count>30);

            var searchStr = "rtabar@hotmail";
            Assert.True(customerDataService.GetCustomerByQueryString(searchStr).Count ==1);
        }
    }
}