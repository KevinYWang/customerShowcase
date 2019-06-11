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
            var result = customerDataService.GetCustomerByQueryString(string.Empty, 1, 50, out var total).Count;
            Assert.True(result > 30);
            Assert.True(total >= result);

            var searchStr = "rtabar@hotmail";
            result = customerDataService.GetCustomerByQueryString(searchStr, 1, 50, out total).Count;
            Assert.True(result == 1);
            Assert.True(total == 1);
        }
    }
}