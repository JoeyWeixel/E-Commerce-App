import {  useState } from "react";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import HomePage from "./Pages/HomePage";
import CartPage from "./Pages/CartPage";
import CustomerPage from "./Pages/CustomerPage";
import Header from "./Components/Header";
import "./Styles/App.css";
import { CustomerType } from "./Components/Customer";
import { OrdersProvider } from './Contexts/OrdersContext';
import {OrdersPage} from "./Pages/OrdersPage"; 



interface ProductType {
  id: number;
  name: string;
  description: string;
  numInStock: number;
  price: number;
  quantity: number;  

}

function App() {
  const [cart, setCart] = useState<ProductType[]>([]);
  const [currentCustomer, setCurrentCustomer] = useState<CustomerType>();


  const handleUpdateCustomer = (newCustomer: CustomerType) => {
    setCurrentCustomer(newCustomer);
  };

  return (
    <div className="app">
      <OrdersProvider>
      <Router>
      <Header cartItemCount={cart.length} customer={currentCustomer}/>
        <Routes>
          <Route path="/" element={<HomePage setCart={setCart} />}/>
          <Route path="/cart" element={<CartPage cart={cart} setCart={setCart} />}/>
          <Route path="/customers" element={<CustomerPage updateCustomer={handleUpdateCustomer}/>}/>
          <Route path="/OrdersPage" element={<OrdersPage />} /> 
        </Routes>
      </Router>
      </OrdersProvider>
    </div>
  );
}

export default App;
