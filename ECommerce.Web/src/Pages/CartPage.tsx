import React from "react";
import Cart from "../Components/Cart";
import "../Styles/CartStyle.css";

interface ProductType {
  id: number;
  name: string;
  description: string;
  numInStock: number;
  price: number;
  quantity: number;
}

interface CartPageProps {
  cart: ProductType[];
  setCart: React.Dispatch<React.SetStateAction<ProductType[]>>;
}

const CartPage: React.FC<CartPageProps> = ({ cart, setCart }) => {
  return (
    <div>
      <Cart initialItems={cart} setCart={setCart} />
    </div>
  );
};

export default CartPage;
