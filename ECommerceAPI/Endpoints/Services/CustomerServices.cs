
using ECommerceAPI.Endpoints.ResponseObjects

using System.Reflection.Metadata.Ecma335;

namespace ECommerceAPI.Endpoints.Services

{
    public class CustomerServices { }


    public CustomerResponse[] GetAllCustomers()
    {
        //TODO: Reference database which is yet to be created
        CustomerResponse[] products = new CustomerResponse[1];
        return products;
    }

    public CustomerResponse GetProduct(int id)
    {
        //TODO query database
        return new CustomerResponse();
    }

}
