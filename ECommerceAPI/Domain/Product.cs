namespace ECommerceAPI.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public int NumInStock { get; set; }
        public decimal Price { get; set; }

        public Product(int id, string name, string description, int numInStock, decimal price)
        {
            Id = id;
            Name = name;
            Description = description;
            NumInStock = numInStock;
            Price = price;
        }
    }
}