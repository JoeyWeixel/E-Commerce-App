// src/Pages/HomePage.tsx
import "../Styles/HomeStyle.css";
import Product from "../Components/Products";
import { useEffect, useState } from "react";
import {
  Carousel,
  CarouselContent,
  CarouselItem,
  CarouselNext,
  CarouselPrevious,
} from "@/Components/ui/carousel"

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
    <div className="bg-[url('https://www.thevillagernewspaper.com/wordpress/wp-content/uploads/2018/04/RRMathCounts.jpg')] w-full h-full bg-cover">
      <Carousel className="w-2/3 mx-auto mt-16 bg-primary">
        <CarouselContent>
          {products.map((product) => (
            <CarouselItem className="basis-1/6 grow" key={product.id}>
              <Product product={product} />
            </CarouselItem>
          ))}
        </CarouselContent>
        <CarouselPrevious />
        <CarouselNext />
      </Carousel>
    </div>
  );
};

export default HomePage;
