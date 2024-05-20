import React from 'react';
import '../Styles/ProductsStyle.css'; // Ensure this path is correct

interface ProductProps {
  id: number;
  title: string;
  image: string;
  price: number;
}

// eslint-disable-next-line @typescript-eslint/no-unused-vars
const Product: React.FC<ProductProps> = ({ id, title, image, price }) => {
  
    return (

    
    <div className="product">
      <div className="product__info">
        <p>{title}</p>
        <p className="product__price">
          <small>$</small>
          <strong>{price}</strong>
        </p>
      </div>
      <img src={image} alt={title} />
      <button>Add to Basket</button>
    </div>
  );
};

export default Product;
