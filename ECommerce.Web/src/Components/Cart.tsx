import React, { useState } from "react";
import CartItem from "./CartItem";
import "../Styles/CartStyle.css";

import { Typography, Button } from "@material-ui/core";

interface CartProps {
  initialItems: {
    id: number;
    name: string;
    price: number;
    quantity: number;
  }[];
}

const Cart: React.FC<CartProps> = ({ initialItems }) => {
  const [items, setItems] = useState(initialItems);

  const handleRemove = (id: number) => {
    setItems(items.filter((item) => item.id !== id));
  };

  const getTotalPrice = () => {
    return items.reduce((total, item) => total + item.price * item.quantity, 0);
  };

  return (
    <div>
      <Typography variant="h4">Shopping Cart</Typography>
      {items.length === 0 ? (
        <Typography variant="h6">Your cart is empty</Typography>
      ) : (
        <div>
          {items.map((item) => (
            <CartItem key={item.id} item={item} onRemove={handleRemove} />
          ))}
          <Typography variant="h5">
            Total: ${getTotalPrice().toFixed(2)}
          </Typography>
          <Button variant="contained" color="primary">
            Proceed to Checkout
          </Button>
        </div>
      )}
    </div>
  );
};

export default Cart;
