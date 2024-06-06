import React from "react";
import { Button, Typography } from "@mui/material";

interface ProductType {
  id: number;
  name: string;
  description: string;
  numInStock: number;
  price: number;
  quantity: number;
}

interface CartItemProps {
  item: ProductType;
  onRemove: (id: number) => void;
}

const CartItem: React.FC<CartItemProps> = ({ item, onRemove }) => {
  return (
    <div className="cart-item">
      <Typography variant="h6">{item.name}</Typography>
      <Typography variant="body1">Price: ${item.price}</Typography>
      <Typography variant="body1">Quantity: {item.quantity}</Typography>
      <Button variant="contained" color="secondary" onClick={() => onRemove(item.id)}>
        Remove
      </Button>
    </div>
  );
};

export default CartItem;
