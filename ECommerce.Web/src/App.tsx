import React from "react";
import "./App.css";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import HomePage from "./Pages/HomePage";
import CartPage from "./Pages/CartPage";
import Header from "./Components/Header";

interface ProductType {
  id: number;
  name: string;
  description: string;
  numInStock: number;
  price: number;
}

function App() {
  const [cart, setCart] = useState<ProductType[]>([]);


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
        </Routes>
      </Router>
    </div>
  );
}

export default App;
