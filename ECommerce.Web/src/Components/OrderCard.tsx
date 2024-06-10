import { Card, CardContent, CardHeader } from '@/Components/ui/card';
import { OrderType } from '@/Pages/OrdersPage';
import { Accordion, AccordionContent, AccordionItem, AccordionTrigger } from './ui/accordion';


type OrderCardProps = {
    order: OrderType;
}

const OrderCard: React.FC<OrderCardProps> = ({ order }) => {
    const date = new Date(order.orderDate);

    const getOrderTotal = () => {
        return order.products.reduce((accumulator, product) => accumulator + (product.price)*(product.quantity), 0);
    }

    return (
        <Card>
            <CardHeader>
                <h3 className="text-lg mx-auto">Order #{order.id}</h3>
            </CardHeader>
            <CardContent>
                <Accordion type='single' collapsible>
                    <AccordionItem value='item-1'className="border-b-0">
                        <AccordionTrigger>
                            <p>Order Date: {date.getMonth()}/{date.getDay()}/{date.getFullYear()}</p>
                            <p>Order Total: ${getOrderTotal()}</p>
                        </AccordionTrigger>
                        <AccordionContent>
                            <div key="header"  className="flex justify-between text-xl font-bold border-b-2 border-secondary mb-2 pb-2">
                                <p className='w-1/3 text-start'>Product</p>
                                <p className='w-1/3 text-center'>Quantity</p>
                                <p className='w-1/3 text-end'>Price</p>
                            </div>
                            {order.products.map(product => (
                                <div key={product.productId} className="flex justify-between">
                                    <p className='w-1/3 text-start'>{product.productName}</p>
                                    <p className='w-1/3 text-center'>{product.quantity}</p>
                                    <p className='w-1/3 text-end'>${product.price}</p>
                                </div>
                            ))}
                        </AccordionContent>
                    </AccordionItem>
                </Accordion>
            </CardContent>
        </Card>
    );
};

export default OrderCard;