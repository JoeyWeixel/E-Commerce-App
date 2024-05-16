namespace ECommerce.Api.Endpoints.Order.RequestResponse
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public Cart Cart { get; set; }
        public System.DateTime? DeliveryDate { get; set; }
        public System.DateTime OrderDate { get; set; }
    }
}
