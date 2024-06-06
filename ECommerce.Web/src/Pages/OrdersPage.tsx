import { useState, useEffect } from 'react';
import { useCustomer } from '@/Contexts/CustomerContext';

type Order = {
    id: number;
    cart: CartType | null;
};

type CartType = {
    id: number;
    products: PurchaseProductType[];
};

type PurchaseProductType = {
    productId: number;
    quantity: number;
    productName: string;
};

type OrdersPageProps = Record<string, never>;

export const OrdersPage: React.FC<OrdersPageProps> = () => {
    const { currentCustomer } = useCustomer();
    const [orders, setOrders] = useState<Order[]>([]);
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
        <div>
            <h1>Orders</h1>

            {error ? (
                <p style={{ color: "red" }}>{error}</p>
            ) : orders.length === 0 ? (
                <p>No orders found.</p>
            ) : (
                orders.map((order: Order, index: number) => (
                    <div key={index}>
                        <h1>Order:</h1>
                        <h2>ID: {order.id}</h2>
                        <ul>
                            {order.cart && order.cart.products ? (
                                order.cart.products.map((product, idx) => (
                                    <li key={idx}>
                                        Product ID: {product.productId}, Quantity: {product.quantity}, Name: {product.productName}
                                    </li>
                                ))
                            ) : (
                                <li>No products in this order.</li>
                            )}
                        </ul>
                    </div>
                ))
            )}
        </div>
    );
};

export default OrdersPage;
