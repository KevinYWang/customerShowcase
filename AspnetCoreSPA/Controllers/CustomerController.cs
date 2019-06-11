using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerShowcase.common.Services;
using Microsoft.AspNetCore.Mvc;

namespace CustomerShowcase.web.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerDataService _customerDataService;

        public CustomerController(ICustomerDataService customerDataService)
        {
            this._customerDataService = customerDataService;
        }

        [HttpGet]
        public IActionResult GetCustomerListBySearchingString(string searchString, int pageNumber, int pageSize)
        {
            var customerList = _customerDataService.GetCustomerByQueryString(searchString, pageNumber, pageSize, out var total);

            if (customerList != null && customerList.Count > 0)
                return Json(new {data = customerList, total=total});

            return BadRequest("Error in fetching customer list.");
        }
    }
}