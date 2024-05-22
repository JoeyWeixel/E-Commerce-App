import React, { useState } from "react";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import HomePage from "./Pages/HomePage";
import CartPage from "./Pages/CartPage";
import CustomerPage from "./Pages/CustomerPage";
import Header from "./Components/Header";
import "./App.css";
interface ProductType {
  id: number;
  name: string;
  description: string;
  numInStock: number;
  price: number;
}

interface ContactInfoType {
  name: string,
  email: string,
  address: string,
  phoneNumber: string
}
interface CustomerType {
  id: number,
  contactInfo: ContactInfoType
}

function App() {
  const [cart, setCart] = useState<ProductType[]>([]);
  const [customers, setCustomers] = useState<CustomerType[]>([]);

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