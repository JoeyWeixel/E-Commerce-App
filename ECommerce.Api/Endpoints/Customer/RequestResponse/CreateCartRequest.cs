namespace ECommerceAPI.Endpoints.ResponseObjects
{
    public class CreateCartRequest
    {
        public Dictionary<GetProductsResponse, int> Products { get; set; }

        public int CustomerID { get; set; }
    }
}
