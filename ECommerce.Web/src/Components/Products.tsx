import "../Styles/ProductsStyle.css";
import { useCustomer } from "@/Contexts/CustomerContext";
import { Card, CardContent, CardFooter, CardHeader } from "./ui/card";
import { Button } from "./ui/button";

interface ProductType {
  id: number;
  name: string;
  description: string;
  numInStock: number;
  price: number;
  quantity: number;
}

interface ProductProps {
  product: ProductType;
}

const Product: React.FC<ProductProps> = ({ product }) => {
  const {currentCustomer} = useCustomer();
  const addToCart = () => {
    if (!currentCustomer) {
      alert("Please select a customer first.");
      return;
    }
    fetch('https://localhost:7249/customers/' + currentCustomer.id + '/cart/products', 
    {
      method: 'POST',
      headers: {
          'accept': '*/*',
          'Content-Type': 'application/json'
      },
      body: JSON.stringify({
          'productId': product.id,
          'quantity': 1
      })
    })
    .then(response => {
      if (!response.ok) {
        throw new Error('Network response was not ok');
      }
      return response.json();
    })
    .catch(error => console.error('Error adding to cart:', error));
  };

  return (
    <Card className="flex flex-col justfy-between itmes-center">
      <CardHeader>
        <h3 className="text-lg mx-auto">{product.name}</h3>
      </CardHeader>
      <CardContent className="flex flex-col justify-between items-center">
        <img src="https://via.placeholder.com/150" alt={product.name} className="mb-2" />
        <p>{product.description}</p>
        <p className="text-sm">Price: ${product.price}</p>
        <p className="text-sm">In Stock: {product.numInStock}</p>
      </CardContent>
      <CardFooter>
        <Button className="hover:bg-card-foreground hover:text-card text-card-foreground border-card-foreground border-[1px] bg-card mx-auto" onClick={addToCart}>Add to Cart</Button>
      </CardFooter>
    </Card>
  );
};

export default Product;
