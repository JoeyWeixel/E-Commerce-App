namespace ECommerceAPI.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int numInStock { get; set; }
        public double Price { get; set; }

        public Product() { }

        public Product(int id, string name, string description, int numInStock, double price)
        {
            Id = id;
            Name = name;
            Description = description;
            this.numInStock = numInStock;
            Price = price;
        }
    }
}