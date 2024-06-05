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
      fetch(`https://localhost:7249/customers/${currentCustomer.id}/cart`, {})
        .then(response => response.json())
        .then(data => setCart(data.products));
    }
  }, [currentCustomer]);

  return (
    <div>
      <Cart initialItems={cart} setCart={setCart} currentCustomer={currentCustomer} />
    </div>
  );
};

export default CartPage;
