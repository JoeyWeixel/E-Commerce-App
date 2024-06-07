import React, { useState, useEffect } from "react";
import CartItem from "./CartItem";
import "../Styles/CartStyle.css";
import { CustomerType } from '../Components/Customer';
import { Link, useNavigate } from "react-router-dom";
import { Label } from "@/Components/ui/label";
import { Button } from "@/Components/ui/button";

interface ProductType {
  id: number;
  name: string;
  description: string;
  numInStock: number;
  price: number;
  quantity: number;
}

interface CartProps {
  items: ProductType[];
  setCart: React.Dispatch<React.SetStateAction<ProductType[]>>;
  currentCustomer: CustomerType | null;
}

const Cart: React.FC<CartProps> = ({ items, setCart, currentCustomer }) => {
  const [cartItems, setCartItems] = useState<ProductType[]>(items);
  const navigate = useNavigate();

  useEffect(() => {
    setCartItems(items);
  }, [items]);

  const handleRemove = async (id: number) => {
    if (currentCustomer) {
      try {
        const response = await fetch(`https://localhost:7249/customers/${currentCustomer.id}/cart/products/${id}`, {
          method: 'DELETE',
        });

        if (response.ok) {
          const updatedItems = cartItems.filter((item) => item.id !== id);
          setCartItems(updatedItems);
          setCart(updatedItems);
        } else {
          alert("Failed to remove item. Please try again.");
        }
      } catch (error) {
        console.error("Error removing item:", error);
        alert("An error occurred while removing the item.");
      }
    } else {
      alert("Customer not found.");
    }
  };

  const getTotalPrice = () => {
    return cartItems.reduce((total, item) => total + item.price * item.quantity, 0);
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
              products: cartItems.map(item => ({
                productId: item.id,
                quantity: item.quantity,
              })),
            },
          }),
        });

        if (response.ok) {
          alert("Order placed successfully!");
          setCartItems([]);
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
    <div className="w-screen flex flex-col items-center py-8">
      <Label className="text-3xl my-4">
        Shopping Cart
      </Label>
      {cartItems.length === 0 ? (
        <>
          <Label>Your cart is empty</Label>
          <Button asChild>
            <Link to="/">Go Shopping</Link>
          </Button>
        </>
      ) : (
        <div className="flex flex-col gap-4 w-2/3">
          {cartItems.map((item) => (
            <CartItem key={item.id} item={item} onRemove={handleRemove} />
          ))}
          <Label className="text-center text-xl">
            Total: ${getTotalPrice().toFixed(2)}
          </Label>
          <Button className="bg-blue-500" onClick={handleCheckout}>
            Proceed to Checkout
          </Button>
        </div>
      )}
    </div>
  );
};

export default Cart;
