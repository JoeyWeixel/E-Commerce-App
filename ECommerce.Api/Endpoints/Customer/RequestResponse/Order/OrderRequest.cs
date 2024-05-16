namespace ECommerceAPI.Endpoints.Customer.RequestResponse.Order
{
    public class OrderRequest
    {
        public int Id { get; set; }
        public Domain.Cart Cart { get; set; }
        public DateTime OrderDate { get; set; }

    }
}
