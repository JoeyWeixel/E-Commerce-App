import { createContext, useState, ReactNode } from 'react';

type Order = {
    name: string;
    quantity: number;
    total: number;
};

type OrdersContextType = {
    orders: Order[];
    addOrder: (order: Order) => void;
};

export const OrdersContext = createContext<OrdersContextType>({
    orders: [],
    addOrder: () => {},
});

export const OrdersProvider = ({ children }: { children: ReactNode }) => {
    const [orders, setOrders] = useState<Order[]>([]);

    const addOrder = (order: Order) => {
        setOrders([...orders, order]);
    };

    return (
        <OrdersContext.Provider value={{ orders, addOrder }}>
            {children}
        </OrdersContext.Provider>
    );
};

