// src/App.tsx
import React, { useState } from 'react';
import Header from './Components/Header';
import HomePage from './Pages/HomePage';
import './App.css';

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
    <div className="App">
      <Header cartItemCount={cart.length} />
      <HomePage setCart={setCart} />
    </div>
  );
}

export default App;
