import React from 'react';
import { Outlet } from 'react-router-dom';
import  Header from '@/Components/navigation/Header.tsx';
import {CustomerContext} from '@/Contexts/CustomerContext';

const AppLayout = () => {
    return (
        <div className="flex flex-col w-screen items-start">
            <CustomerContext >
                <Header />
                <Outlet />
            </CustomerContext>
        </div>
    )
}

export default AppLayout