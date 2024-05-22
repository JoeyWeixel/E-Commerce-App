import React from "react";
import Cart from "../Components/Cart";
import "../Styles/CartStyle.css";

const initialCartItems = [
  { id: 1, name: "Product 1", price: 29.99, quantity: 1 },
  { id: 2, name: "Product 2", price: 49.99, quantity: 2 },
  { id: 3, name: "Product 3", price: 9.99, quantity: 2 },
  { id: 4, name: "Product 4", price: 109.99, quantity: 5 },
  { id: 5, name: "Product 5", price: 499.99, quantity: 3 },
  { id: 6, name: "Product 6", price: 999.99, quantity: 1000 },
];

const CartPage: React.FC = () => {
  return (
    <div style={{ padding: "20px" }}>
      <Cart initialItems={initialCartItems} />
    </div>
  );
};

export default CartPage;
