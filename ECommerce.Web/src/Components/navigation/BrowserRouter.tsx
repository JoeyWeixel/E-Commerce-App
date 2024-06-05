import { createBrowserRouter } from 'react-router-dom';
import AppLayout from './AppLayout';
import HomePage from '@/Pages/HomePage';
import CartPage from '@/Pages/CartPage';
import CustomerPage from '@/Pages/CustomerPage';
import OrdersPage from '@/Pages/OrdersPage';

const BrowserRouter = createBrowserRouter([
  {
    path: '/',
    element: <AppLayout />,
    children: [
      {
        path: '',
        element: <HomePage />,
      },
      {
        path: 'cart',
        element: <CartPage />,
      },
      {
        path: 'customer',
        element: <CustomerPage />,
      },
      {
        path: 'orders',
        element: <OrdersPage />,
      },
    ],
  },
]);

export default BrowserRouter;
