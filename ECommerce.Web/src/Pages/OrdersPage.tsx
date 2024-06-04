import { useContext } from 'react';
import { OrdersContext } from '../Contexts/OrdersContext';
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
        if (currentCustomer) {
            fetch(`http://localhost:7249/customers/${currentCustomer.id}/orders`)
                .then(response => {
                    if (!response.ok) {
                        throw new Error('Network response was not ok');
                    }
                    return response.json();
                })
                .then(data => setOrders(data))
                .catch(error => console.error('Error fetching orders:', error));
        }
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
