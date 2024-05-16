// clientapp/src/App.js
import React from 'react';
import './App.css';
import ProductList from './ProductList';

function App() {
    return (
        <div className="App">
            <header className="App-header">
                <h1>Welcome to ECommerce</h1>
            </header>
            <ProductList />
        </div>
    );
}

export default App;
