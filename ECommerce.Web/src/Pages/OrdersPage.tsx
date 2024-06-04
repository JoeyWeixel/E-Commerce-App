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

export const OrdersPage: React.FC<OrdersPageProps> = ({ currentCustomer }) => {
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
             <h2>Order ID: {order.id}</h2>
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
  };

  export default OrdersPage;