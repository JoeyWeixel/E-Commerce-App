import React, { useState, useEffect } from "react";
import CartItem from "./CartItem";
import "../Styles/CartStyle.css";

import { Typography, Button } from "@mui/material";

interface ProductType {
  id: number;
  name: string;
  description: string;
  numInStock: number;
  price: number;
  quantity: number;
}

interface CartProps {
  initialItems: ProductType[];
  setCart: React.Dispatch<React.SetStateAction<ProductType[]>>;
}

const Cart: React.FC<CartProps> = ({ initialItems, setCart }) => {
  const [items, setItems] = useState<ProductType[]>(initialItems);

  useEffect(() => {
    setItems(initialItems);
  }, [initialItems]);

  const handleRemove = (id: number) => {
    const updatedItems = items.filter((item) => item.id !== id);
    setItems(updatedItems);
    setCart(updatedItems);
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
