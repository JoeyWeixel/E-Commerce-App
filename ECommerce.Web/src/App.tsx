import React from "react";
import "./App.css";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import HomePage from "./Pages/HomePage";
import CartPage from "./Pages/CartPage";
import Header from "./Components/Header";

const App: React.FC = () => {
  return (
    <div className="app">
      <Router>
        <Routes>
          <Route
            path="/"
            element={
              <>
                <Header />
                <HomePage />
              </>
            }
          />
          <Route
            path="/cart"
            element={
              <>
                <Header />
                <CartPage />
              </>
            }
          />
        </Routes>
      </Router>
    </div>
  );
};

export default App;
