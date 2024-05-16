namespace ECommerceAPI.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int numInStock { get; set; }
        public double Price { get; private set; }

        public Product()
        {
                
        }

        public void SetPrice(double price)
        {
            if(price < 0)
            {
                throw new ArgumentException("Price Cant be Negative"); 
            }
            Price = price; 
        }
    }
}