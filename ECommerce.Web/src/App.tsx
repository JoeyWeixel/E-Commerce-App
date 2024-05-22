import React, { useState } from "react";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import HomePage from "./Pages/HomePage";
import CartPage from "./Pages/CartPage";
import Header from "./Components/Header";
import "./App.css";
interface ProductType {
  id: number;
  name: string;
  description: string;
  numInStock: number;
  price: number;
}

function App() {
  const [cart, setCart] = useState<ProductType[]>([]);

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
            path="/"
            element={
              <>
                <Header cartItemCount={cart.length} />
                <CartPage />
              </>
            }
          />
        </Routes>
      </Router>
    </div>
  );
}

export default App;
