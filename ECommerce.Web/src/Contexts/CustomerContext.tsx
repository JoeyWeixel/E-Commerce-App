// CustomerContext.tsx
import React, { createContext, useState, useContext } from 'react';

export type ContactInfoType = {
  name: string;
  email: string;
  address: string;
  phoneNumber: string;
};

export type CustomerType = {
  id: number;
  contactInfo: ContactInfoType;
};

export type ProductType = {
  id: number;
  name: string;
  description: string;
  numInStock: number;
  price: number;
  quantity: number;
};

interface CustomerContextType {
  currentCustomer: CustomerType | null;
  setCurrentCustomer: React.Dispatch<React.SetStateAction<CustomerType | null>>;
  cartItems: ProductType[];
  setCartItems: React.Dispatch<React.SetStateAction<ProductType[]>>;
  addToCart: (product: ProductType) => void; // Add this line
}

const CustomerContext = createContext<CustomerContextType | undefined>(undefined);

export const useCustomer = () => {
  const context = useContext(CustomerContext);
  if (!context) {
    throw new Error('useCustomer must be used within a CustomerProvider');
  }
  return context;
};

export const CustomerProvider: React.FC<{ children: React.ReactNode }> = ({ children }) => {
  const [currentCustomer, setCurrentCustomer] = useState<CustomerType | null>(null);
  const [cartItems, setCartItems] = useState<ProductType[]>([]);

  const addToCart = (product: ProductType) => {
    setCartItems(prevItems => {
      const existingItem = prevItems.find(item => item.id === product.id);
      if (existingItem) {
        return prevItems.map(item =>
          item.id === product.id ? { ...item, quantity: item.quantity + 1 } : item
        );
      }
      return [...prevItems, { ...product, quantity: 1 }];
    });
  };

  return (
    <CustomerContext.Provider value={{ currentCustomer, setCurrentCustomer, cartItems, setCartItems, addToCart }}>
      {children}
    </CustomerContext.Provider>
  );
};
