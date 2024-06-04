import React, { useState, useEffect } from "react";
import CartItem from "./CartItem";
import "../Styles/CartStyle.css";
import { Typography, Button } from "@mui/material";
import { useNavigate } from "react-router-dom";
import { CustomerType } from "./Customer";

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
  currentCustomer: CustomerType | null;
}

const Cart: React.FC<CartProps> = ({ initialItems, setCart, currentCustomer }) => {
  const [items, setItems] = useState<ProductType[]>(initialItems);
  const navigate = useNavigate();

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

  const handleCheckout = async () => {
    if (!currentCustomer) {
      alert('Please select a customer before checking out.');
      return;
    }

    try {
      const response = await fetch(`http://localhost:7249/customers/${currentCustomer.id}/orders`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify({
          cart: { products: items }
        })
      });

      if (!response.ok) {
        throw new Error('Failed to place order');
      }

      alert(`You just ordered:\n${items.map(item => `${item.name} (x${item.quantity})`).join('\n')}\n\nTotal price: $${getTotalPrice().toFixed(2)}`);

      setItems([]);
      setCart([]);
      navigate("/OrdersPage");
    } catch (error) {
      console.error('Error during checkout:', error);
      alert('Error during checkout. Please try again.');
    }
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
          <Button variant="contained" color="primary" onClick={handleCheckout}>
            Proceed to Checkout
          </Button>
        </div>
      )}
    </div>
  );
};

export default Cart;
