using ECommerceAPI.Endpoints.ResponseObjects;

namespace ECommerceAPI.Endpoints.Services;
using ECommerceAPI.Endpoints.ResponseObjects;
public class ContactInfoServices
{
    public ContactInfoServices() { }

    public GetContactInfoResponse GetContactInfo(int id)
    {
        return new GetContactInfoResponse { Name = "Test", Email = "test.gibson@neudesic.com", PhoneNumber = "test-test-test", Address = "250 S High St" };
    }
}