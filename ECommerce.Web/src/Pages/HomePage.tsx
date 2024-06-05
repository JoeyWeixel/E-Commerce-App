// src/Pages/HomePage.tsx
import "../Styles/HomeStyle.css";
import Product from "../Components/Products";
import { useEffect, useState } from "react";
interface ProductType {
  id: number;
  name: string;
  description: string;
  numInStock: number;
  price: number;
  quantity: number;
}

type HomePageProps = Record<string, never>;

const HomePage: React.FC<HomePageProps> = () => {
  const [products, setProducts] = useState<ProductType[]>([]);

  useEffect(() => {
    // Fetch products from the API
    fetch("https://localhost:7249/products")
      .then((response) => {
        if (!response.ok) {
          throw new Error("Network response was not ok");
        }
        return response.json();
      })
      .then((data) => setProducts(data))
      .catch((error) => console.error("Error fetching products:", error));
  }, []);

  return (
    <div className="home">
      <div className="home__container">
        <img
          className="home__image"
          src="https://www.thevillagernewspaper.com/wordpress/wp-content/uploads/2018/04/RRMathCounts.jpg"
          alt=""
        />
        <div> 
          {
            products.map((product) => (
              <Product key={product.id} product={product} />
            ))
          }
        </div>
      </div>
    </div>
  );
};

export default HomePage;
