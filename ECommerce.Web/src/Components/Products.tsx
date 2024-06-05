import "../Styles/ProductsStyle.css";
import { useCustomer } from "@/Contexts/CustomerContext";

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
          'productId': product.id
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
    <div className="product">
      <div className="product__info">
        <p>{product.name}</p>
        <p className="product__price">
          <small>$</small>
          <strong>{product.price}</strong>
        </p>
        <p>{product.description}</p>
      </div>
      <img src="https://via.placeholder.com/150" alt={product.name} />
      <button onClick={addToCart}>Add to Basket</button>
    </div>
  );
};

export default Product;
