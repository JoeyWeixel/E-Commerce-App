import React from 'react';
import Cart from '../Components/Cart';

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
  return <Cart initialItems={cart} setCart={setCart} />;
};

export default CartPage;
