namespace ECommerceAPI.Endpoints.CustomerEndpoint.RequestResponse
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
