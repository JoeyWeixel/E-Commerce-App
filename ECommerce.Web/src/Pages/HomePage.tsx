// src/Pages/HomePage.tsx
import '../Styles/HomeStyle.css';
import Products from '../Components/Products';

interface ProductType {
  id: number;
  name: string;
  description: string;
  numInStock: number;
  price: number;
}

const HomePage: React.FC<{ setCart: React.Dispatch<React.SetStateAction<ProductType[]>> }> = ({ setCart }) => {
  return (
    <div className="home">
      <div className="home__container">
        <img
          className="home__image"
          src="https://www.thevillagernewspaper.com/wordpress/wp-content/uploads/2018/04/RRMathCounts.jpg"
          alt=""
        />
        <Products setCart={setCart} />
      </div>
    </div>
  );
};

export default HomePage;
