import React from "react";
import { Button } from "./ui/button";
import { Card, CardContent, CardHeader } from "./ui/card";
import { Label } from "./ui/label";

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

    <Card className="w-full">
      <CardHeader className="pb-0">
        <Label className="text-xl">{item.name}</Label>
      </CardHeader>
      <CardContent className="flex justify-between items-center ">
        <Label>Price: ${item.price}</Label>
        <Label>Quantity: {item.quantity}</Label>
        <Button variant="destructive" onClick={() => onRemove(item.id)}>
          Remove
        </Button>
      </CardContent>
    </Card>
  );
};

export default CartItem;
