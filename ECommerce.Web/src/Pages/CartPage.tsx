import React, { useState, useEffect } from "react";
import Cart from "../Components/Cart";
import "../Styles/CartStyle.css";
import { useCustomer } from "@/Contexts/CustomerContext";

interface ProductType {
  id: number;
  name: string;
  description: string;
  numInStock: number;
  price: number;
  quantity: number;
}

const CartPage: React.FC = () => {
  const { currentCustomer } = useCustomer();
  const [cart, setCart] = useState<ProductType[]>([]); 

  useEffect(() => {
    if (currentCustomer) { 
      fetch(`https://localhost:7249/customers/${currentCustomer.id}/cart`)
        .then(response => {
          if (!response.ok) {
            throw new Error("Network response was not ok"); 
          }
          return response.json();
        })
        .then(data => {
          const productFetches = data.products.map((product: { productId: number, quantity: number }) => 
            fetch(`https://localhost:7249/products/${product.productId}`)
              .then(response => {
                if (!response.ok) {
                  throw new Error("Network response was not ok"); 
                }
                return response.json();
              })
              .then(productData => ({
                ...productData, 
                quantity: product.quantity,
              }))
          );

          Promise.all(productFetches)
            .then(fetchedProducts => setCart(fetchedProducts)) 
            .catch(error => console.error("Error fetching product details:", error)); 
        })
        .catch(error => console.error("Error fetching cart:", error));
    }
  }, [currentCustomer]); 

  return (
    <div className="w-1/2">
      <Cart items={cart} setCart={setCart} currentCustomer={currentCustomer} />
    </div>
  );
};

export default CartPage;
