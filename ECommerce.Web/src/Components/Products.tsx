import React, { useEffect, useState } from 'react';
import '../Styles/ProductsStyle.css';

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
  addToCart: (product: ProductType) => void;
}

const Product: React.FC<ProductProps> = ({ product, addToCart }) => {
  const handleAddToCart = () => {
    addToCart(product);
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
      <button onClick={handleAddToCart}>Add to Basket</button>
    </div>
  );
};

interface ProductsProps {
  setCart: React.Dispatch<React.SetStateAction<ProductType[]>>;
}

const Products: React.FC<ProductsProps> = ({ setCart }) => {
  const [products, setProducts] = useState<ProductType[]>([]);

  useEffect(() => {
    // Fetch products from the API
    fetch('https://localhost:7249/products') 
      .then(response => {
        if (!response.ok) {
          throw new Error('Network response was not ok');
        }
        return response.json();
      })
      .then(data => setProducts(data))
      .catch(error => console.error('Error fetching products:', error));
  }, []);


  const addToCart = (product: ProductType) => {
    setCart(prevCart => [...prevCart, product]);
  };

  return (
    <div className="products-page">
      <div className="products">
        {products.map(product => (
          <Product key={product.id} product={product} addToCart={addToCart} />
        ))}
      </div>
    </div>
  );
};

export default Products;
