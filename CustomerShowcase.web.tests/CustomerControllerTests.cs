using System;
using CustomerShowcase.web.Controllers;
using Xunit;

namespace CustomerShowcase.web.tests
{
    public class CustomerControllerTests
    {
        private CustomerController customerController;

        public CustomerControllerTests()
        {
            this.customerController = new CustomerController();
        }


        [Fact]
        public void CustomerControllerTestsWithoutQuery()
        {
            var results = customerController.GetCustomers();
            Assert.NotNull(results);
        }
    }
}
