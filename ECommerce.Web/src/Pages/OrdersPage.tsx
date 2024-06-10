import { useState, useEffect } from 'react';
import { useCustomer } from '@/Contexts/CustomerContext';
import OrderCard from '@/Components/OrderCard';

export type OrderType = {
    id: number;
    orderDate: string;
    products: PurchaseProductType[];
};

type PurchaseProductType = {
    productId: number;
    quantity: number;
    productName: string;
    price: number;
};

type OrdersPageProps = Record<string, never>;

export const OrdersPage: React.FC<OrdersPageProps> = () => {
    const { currentCustomer } = useCustomer();
    const [orders, setOrders] = useState<OrderType[]>([]);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        let isMounted = true;

        if (currentCustomer?.id) {
            fetch(`https://localhost:7249/customers/${currentCustomer.id}/orders`, {
                method: 'GET',
                headers: { 'Content-Type': 'application/json' },
            })
                .then(response => {
                    if (!response.ok) {
                        if (response.status === 404) {
                            throw new Error('Customer not found');
                        } else {
                            throw new Error('Network response was not ok. Status: ' + response.status);
                        }
                    }
                    return response.json();
                })
                .then(data => {
                    if (isMounted) {
                        setOrders(data);
                        setError(null);
                    }
                })
                .catch(error => {
                    if (isMounted) {
                        console.error('Fetch Error:', error);
                        setError('Error fetching orders: ' + error.message);
                    }
                });
        } else {
            alert("Please select a customer first.");
            return;
        }

        return () => { isMounted = false; };
    }, [currentCustomer?.id]);

    return (
        <div className='w-screen h-full'>
            <h1 className='text-2xl font-bold'>Orders</h1>
            {error && <p className='text-red-500'>{error}</p>}
            <div className='flex flex-col space-y-4'>
                {orders.map(order => (
                    <OrderCard key={order.id} order={order}></OrderCard>
                ))}
            </div>
        </div>
    );
};

export default OrdersPage;
