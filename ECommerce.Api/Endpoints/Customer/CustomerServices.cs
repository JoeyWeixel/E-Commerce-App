using ECommerceAPI.Endpoints.Customer.RequestResponse;

namespace ECommerceAPI.Endpoints.Customer
{
    public class CustomerService
    {

        public CustomerService() { }

        public IEnumerable<CustomerResponse> GetAllCustomers()
        {
            //TODO: Reference database which is yet to be created
            var products = new List<CustomerResponse>();
            return products;
        }

        public CustomerResponse GetCustomer(int id)
        {
            //TODO query database
            return new CustomerResponse();
        }

        public void DeleteCustomer(int id)
        {
            //TODO
        }

        public CustomerResponse AddCustomer(CustomerRequest product)
        {
            return new CustomerResponse
            {
                Id = Guid.NewGuid().ToString(),
            };
        }
    }
}
