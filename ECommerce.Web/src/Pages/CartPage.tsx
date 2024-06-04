import React from 'react';
import Cart from '../Components/Cart';
import { CustomerType } from '../Components/Customer';

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
  currentCustomer: CustomerType | null;
}

const CartPage: React.FC<CartPageProps> = ({ cart, setCart, currentCustomer }) => {
  return (
    <div>
      <Cart initialItems={cart} setCart={setCart} currentCustomer={currentCustomer} />
    </div>
  );
};

export default CartPage;
