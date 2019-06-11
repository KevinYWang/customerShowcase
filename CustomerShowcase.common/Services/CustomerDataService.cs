using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CustomerShowcase.common.Model;
using GemBox.Spreadsheet;

namespace CustomerShowcase.common.Services
{
    public interface ICustomerDataService
    {
        List<Customer> GetCustomerByQueryString(string searchStr);
        List<Customer> GetCustomerDataFromCsvFile(string dataFilePath);
    }

    public class CustomerDataService : ICustomerDataService
    {
        private List<Customer> customerRepository;

        public CustomerDataService(string dataFilePath)
        {
            customerRepository = GetCustomerDataFromCsvFile(dataFilePath);
        }

        public List<Customer> GetCustomerByQueryString(string searchStr)
        {
            List<Customer> customerList = new List<Customer>();
            if (string.IsNullOrEmpty(searchStr) || string.IsNullOrWhiteSpace(searchStr))
            {
                return customerRepository
                    .OrderBy(x => x.FirstName)
                    .ThenBy(y => y.LastName)
                    .ThenBy(z => z.Email)
                    .ToList();
            }

            var firstNamList = customerRepository.Where(x => x.FirstName.ToLower().Contains(searchStr.ToLower()));
            var lastNameList = customerRepository.Where(x => x.LastName.ToLower().Contains(searchStr.ToLower()));
            var phoneList = customerRepository.Where(x => x.Phone.Contains(searchStr));
            var emailList = customerRepository.Where(x => x.Email.ToLower().Contains(searchStr.ToLower()));


            var combinedList = firstNamList
                .Concat(lastNameList)
                .Concat(phoneList)
                .Concat(emailList)
                .Distinct()
                .OrderBy(x => x.FirstName)
                .ThenBy(y => y.LastName)
                .ThenBy(z => z.Email)
                .ToList();


            return combinedList;
        }

        public List<Customer> GetCustomerDataFromCsvFile(string dataFilePath)
        {
            List<Customer> customerList = new List<Customer>();

            ExcelFile customerCsvFile = null;
            try

            {
                customerCsvFile = ExcelFile.Load(dataFilePath, LoadOptions.CsvDefault);

                if (customerCsvFile == null
                    || customerCsvFile.Worksheets.Count < 1
                    || customerCsvFile.Worksheets[0].Rows.Count < 1)
                {
                    throw new FileLoadException("No data");
                }
            }
            catch (Exception ex)
            {
                throw new FileLoadException("Failed to read CSV file", ex);
            }

            var dataSheet = customerCsvFile.Worksheets[0];

            //skip the header row
            // data columns: first_name,last_name,company_name,address,city,state,post,phone1,phone2,email,web
            foreach (var row in dataSheet.Rows.Skip(1))
            {
                if (row.Cells[0].Value == null || row.Cells[1].Value == null)
                    continue;
                customerList.Add(new Customer()
                {
                    FirstName = row.Cells[0].Value.ToString(),
                    LastName = row.Cells[1].Value.ToString(),
                    Phone = row.Cells[7].Value.ToString(),
                    Email = row.Cells[9].Value.ToString()
                });
            }

            return customerList;
        }
    }
}