using ECommerceAPI.Domain;

namespace ECommerce.Api.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public Cart Cart { get; set; }
        public System.DateTime ?DeliveryDate { get; set; }
        public System.DateTime OrderDate { get; set; }

    }
}
