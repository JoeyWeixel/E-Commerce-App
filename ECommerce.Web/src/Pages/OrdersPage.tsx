import { useState, useEffect } from 'react';
import { CustomerType } from '../Components/Customer';

type Order = {
    id: number;
    cart: CartType;
};

type CartType = {
    id: number;
    products: PurchaseProductType[];
};

type PurchaseProductType = {
    productId: number;
    quantity: number;
};

type OrdersPageProps = {
    currentCustomer: CustomerType | null;
};

export function OrdersPage({ currentCustomer }: OrdersPageProps) {
    const [orders, setOrders] = useState<Order[]>([]);

    useEffect(() => {
        const loadOrders = async () => {
            if (currentCustomer) {
                try {
                    const response = await fetch(`http://localhost:7249/customers/${currentCustomer.id}/orders`);
                    if (!response.ok) {
                        throw new Error('Network response was not ok');
                    }
                    const data = await response.json();
                    setOrders(data);
                } catch (error) {
                    console.error('Error fetching orders:', error);
                }
            }
        };

        loadOrders();
    }, [currentCustomer]);

    return (
        <div>
            <h1>Orders</h1>
            {orders.length === 0 ? (
                <p>No orders found.</p>
            ) : (
                orders.map((order: Order, index: number) => (
                    <div key={index}>
                        <h2>Order ID: {order.id}</h2>
                        <h3>Cart</h3>
                        <ul>
                            {order.cart.products.map((product, idx) => (
                                <li key={idx}>
                                    Product ID: {product.productId}, Quantity: {product.quantity}
                                </li>
                            ))}
                        </ul>
                    </div>
                ))
            )}
        </div>
    );
}
