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
import { Label } from "@/Components/ui/label";

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
    <div className="bg-[url('https://www.thevillagernewspaper.com/wordpress/wp-content/uploads/2018/04/RRMathCounts.jpg')] w-full h-full bg-cover flex flex-col pt-16">
      <Label className="text-4xl text-center text-card-foreground bg-card mx-auto p-4 rounded-md underline decoration-2 decoration-secondary underline-offset-8">Our Products</Label>
      <div className="mx-auto max-w-max min-w-[500px] flex justify-center items-start my-4 bg-card py-4 rounded-xl border-2 border-secondary">
        <Carousel className="w-full mx-16 flex justify-center">
          <CarouselContent className="">
            {products.map((product) => (
              <CarouselItem className="basis-1/3 grow min-w-[200px]" key={product.id}>
                <Product product={product} />
              </CarouselItem>
            ))}
          </CarouselContent>
          <CarouselPrevious className="border-2"/>
          <CarouselNext className="border-2"/>
        </Carousel>
      </div>
    </div>
  );
};

export default HomePage;
