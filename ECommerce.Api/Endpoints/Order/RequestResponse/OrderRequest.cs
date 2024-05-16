namespace ECommerceAPI.Endpoints.Order.RequestResponse
{
    public class OrderRequest
    {
        public int Id { get; set; }
        public Domain.Cart Cart { get; set; }
        public DateTime OrderDate { get; set; }

    }
}
