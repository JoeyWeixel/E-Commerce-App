public class ContactInfoServices
{
    public ContactInfoServices() { }

    public GetContactInfoResponse getContactInfo(string email)
    {
        return new GetContactInfoResponse { Name = "Test", Email = "test.gibson@neudesic.com", PhoneNumber = "test-test-test", Address = "250 S High St" };
    }
}