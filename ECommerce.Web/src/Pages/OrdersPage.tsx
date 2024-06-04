import { useContext } from 'react';
import { OrdersContext } from '../Contexts/OrdersContext';

type Order = {
    name: string;
    quantity: number;
    total: number;
};

export function OrdersPage() {
    const { orders } = useContext(OrdersContext);

    return (
        <div>
            <h1>Orders</h1>
            {orders.length === 0 ? (
                <p>No orders found.</p>
            ) : (
                orders.map((order: Order, index: number) => (
                    <div key={index}>
                        <h2>{order.name}</h2>
                        <p>Quantity: {order.quantity}</p>
                        <p>Total: {order.total}</p>
                    </div>
                ))
            )}
        </div>
    );
}
