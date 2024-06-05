import React from 'react';
import { Outlet } from 'react-router-dom';
import Header from '@/Components/navigation/Header';
import { CustomerProvider } from '@/Contexts/CustomerContext';

const AppLayout = () => {
  return (
    <CustomerProvider>
      <div className="flex flex-col w-screen items-start">
        <Header />
        <Outlet />
      </div>
    </CustomerProvider>
  );
};

export default AppLayout;
