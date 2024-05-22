import { useEffect, useState } from "react";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import HomePage from "./Pages/HomePage";
import CartPage from "./Pages/CartPage";
import CustomerPage from "./Pages/CustomerPage";
import Header from "./Components/Header";
import "./App.css";
import { CustomerType } from "./Components/Customer";
interface ProductType {
  id: number;
  name: string;
  description: string;
  numInStock: number;
  price: number;
}

function App() {
  const [cart, setCart] = useState<ProductType[]>([]);
  const [customers, setCustomers] = useState<CustomerType[]>([]);

  useEffect(() => {
      // Fetch customers from the API
      fetch('https://localhost:7249/customers') 
        .then(response => {
          if (!response.ok) {
            throw new Error('Network response was not ok');
          }
          return response.json();
        })
        .then(data => setCustomers(data))
        .catch(error => console.error('Error fetching customers:', error));
    }, []);

  
  return (
    <div className="app">
      <Router>
        <Routes>
          <Route
            path="/"
            element={
              <>
                <Header cartItemCount={cart.length} />
                <HomePage setCart={setCart} />
              </>
            }
          />
          <Route
            path="/cart"
            element={
              <>
                <Header cartItemCount={cart.length} />
                <CartPage />
              </>
            }
          />
          <Route
            path="/customers"
            element={
              <>
                <Header cartItemCount={cart.length} />
                <CustomerPage customers = {customers}/>
              </>
            }
            />
        </Routes>
      </Router>
    </div>
  );
}

export default App;