import React from "react";
import { Button, Card, CardContent, Typography } from "@mui/material";
import "../Styles/CartStyle.css";

interface CartItemProps {
  item: {
    id: number;
    name: string;
    price: number;
    quantity: number;
  };
  onRemove: (id: number) => void;
}

const CartItem: React.FC<CartItemProps> = ({ item, onRemove }) => {
  return (
    <Card style={{ margin: "10px 0" }}>
      <CardContent>
        <Typography className="item__name" variant="h5">
          {item.name}
        </Typography>
        <Typography variant="body2">Price: ${item.price}</Typography>
        <Typography variant="body2">Quantity: {item.quantity}</Typography>
        <Button
          variant="contained"
          color="secondary"
          onClick={() => onRemove(item.id)}
        >
          Remove
        </Button>
      </CardContent>
    </Card>
  );
};

export default CartItem;
