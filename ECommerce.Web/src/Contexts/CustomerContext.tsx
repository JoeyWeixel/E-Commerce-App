import React, { createContext, useState, useContext } from 'react';

interface Customer {
  id: number;
}

interface CustomerContextType {
  currentCustomer: Customer | null;
  setCurrentCustomer: React.Dispatch<React.SetStateAction<Customer | null>>;
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
    const [currentCustomer, setCurrentCustomer] = useState<Customer | null>(null);

    return (
        <CustomerContext.Provider value={{ currentCustomer, setCurrentCustomer }}>
            {children}
        </CustomerContext.Provider>
    );
};
