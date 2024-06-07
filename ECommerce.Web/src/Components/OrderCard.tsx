import { Card, CardContent, CardHeader } from '@/Components/ui/card';
import { OrderType } from '@/Pages/OrdersPage';


type OrderCardProps = {
    order: OrderType;
}

const OrderCard: React.FC<OrderCardProps> = ({ order }) => {
    return (
        <Card>
            <CardHeader>
                <h3 className="text-lg mx-auto">Order #{order.id}</h3>
            </CardHeader>
            <CardContent>
                <p>Order Date: {order.orderDate}</p>
                <p>Order Total: {
                    order.products.reduce((accumulator, product) => accumulator + (product.price)*(product.quantity), 0)
                }</p>
            </CardContent>
        </Card>
    );
};

export default OrderCard;