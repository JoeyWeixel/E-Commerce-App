namespace ECommerceAPI.Endpoints.Customer.RequestResponse.Cart
{
    public class CreateCartRequest
    {
        public Dictionary<GetProductsResponse, int> Products { get; set; }

        public int CustomerID { get; set; }
    }
}
