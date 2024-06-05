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

interface CustomerContextType {
  currentCustomer: CustomerType | null;
  setCurrentCustomer: React.Dispatch<React.SetStateAction<CustomerType | null>>;
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

  return (
    <CustomerContext.Provider value={{ currentCustomer, setCurrentCustomer }}>
      {children}
    </CustomerContext.Provider>
  );
};
