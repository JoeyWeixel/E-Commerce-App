import React, { useState, useEffect } from "react";
import CartItem from "./CartItem";
import "../Styles/CartStyle.css";
import { Typography, Button } from "@mui/material";
import { CustomerType } from '../Components/Customer';
import { useNavigate } from "react-router-dom";

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
    if (currentCustomer) { 
      try {
        const response = await fetch(`https://localhost:7249/customers/${currentCustomer.id}/orders`, {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json',
          },
          body: JSON.stringify({
            cart: {
              products: items.map(item => ({
                productId: item.id,
                quantity: item.quantity,
              })),
            },
          }),
        });

        if (response.ok) {
          alert("Order placed successfully!"); 
          setItems([]); 
          setCart([]);
          navigate("/orders");
        } else {
          alert("Failed to place order. Please try again.");
        }
      } catch (error) {
        console.error("Error placing order:", error);
        alert("An error occurred while placing your order.");
      }
    } else {
      alert("Please select a customer before checking out.");
      navigate("/customers"); 
    }
  };

  return (
    <div>
      <Typography className="title" variant="h4">
        Shopping Cart
      </Typography>
      {items.length === 0 ? (
        <Typography variant="h6">Your cart is empty</Typography>
      ) : (
        <div>
          {
            items.map((item) => (
              <CartItem key={item.id} item={item} onRemove={handleRemove} />
            ))
          }
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