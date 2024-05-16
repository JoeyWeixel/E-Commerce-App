namespace ECommerce.Api.Endpoints.Order.RequestResponse
{
    public class OrderRequest
    {
        public int Id { get; set; }
        public ECommerceAPI.Domain.Cart Cart { get; set; }
        public System.DateTime OrderDate { get; set; }

    }
}
