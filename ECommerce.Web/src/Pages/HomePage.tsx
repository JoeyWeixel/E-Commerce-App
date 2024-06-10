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
import { Label } from "@/Components/ui/label";
import { Dialog, DialogContent, DialogHeader, DialogTitle, DialogTrigger } from "@/Components/ui/dialog";
import { Button } from "@/Components/ui/button";
import { Form, FormControl, FormDescription, FormField, FormItem, FormLabel, FormMessage } from "@/Components/ui/form";
import { Input } from "@/Components/ui/input";
import { z } from "zod";
import { zodResolver } from "@hookform/resolvers/zod";
import { useForm } from "react-hook-form";

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


  const loadData = () => {
    fetch("https://localhost:7249/products")
    .then((response) => {
      if (!response.ok) {
        throw new Error("Network response was not ok");
      }
      return response.json();
    })
    .then((data) => setProducts(data))
    .catch((error) => console.error("Error fetching products:", error));
  }

  useEffect(() => {
    // Fetch products from the API
    loadData();
  }, []);

  const formSchema = z.object({
    name: z.string(),
    description: z.string(),
    price: z.string().refine((value) => !Number.isNaN(parseInt(value, 10)), {
        message: "Price must be a number.",
    }),
    quantity: z.string().refine((value) => !Number.isNaN(parseInt(value, 10)), {
        message: "Quantity must be a number.",
    }),
})

  const form = useForm<z.infer<typeof formSchema>>({
    resolver: zodResolver(formSchema),
    defaultValues: {
        name: "",
        description: "",
        price: "0",
        quantity: "0"
    }
  });

  const onSubmit = (data: z.infer<typeof formSchema>) => {
    fetch("https://localhost:7249/products", {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
          name: data.name,
          description: data.description,
          price: parseFloat(data.price),
          NumInStock: parseInt(data.quantity)
        })
    })
    .then(response => response.json())
    .then(() => loadData())
  }

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
      <Dialog>
        <DialogTrigger asChild>
            <Button variant="outline"  className="w-min p-6 text-center text-xl hover:cursor-pointer absolute bottom-[5%] right-[5%]">List Your Product</Button>
        </DialogTrigger>
        <DialogContent>
            <DialogHeader>
                <DialogTitle>List your product</DialogTitle>
            </DialogHeader>
            <Form {...form}>
                <form onSubmit={form.handleSubmit(onSubmit)}>
                    <FormField
                        control={form.control}
                        name="name"
                        render={({ field }) => (
                            <FormItem>
                            <FormLabel>Name</FormLabel>
                            <FormControl>
                                <Input placeholder="Name" {...field} required/>
                            </FormControl>
                            <FormDescription>
                                Name of your product.
                            </FormDescription>
                            <FormMessage />
                            </FormItem>
                        )}
                    />
                    <FormField
                        control={form.control}
                        name="description"
                        render={({ field }) => (
                            <FormItem>
                            <FormLabel>Description</FormLabel>
                            <FormControl>
                                <Input placeholder="Description" {...field} required />
                            </FormControl>
                            <FormDescription>
                                Provide a brief description of your product.
                            </FormDescription>
                            <FormMessage />
                            </FormItem>
                        )}
                    />
                    <FormField
                        control={form.control}
                        name="price"
                        render={({ field }) => (
                            <FormItem>
                            <FormLabel>Price</FormLabel>
                            <FormControl>
                                <Input {...field} required type="number"/>
                            </FormControl>
                            <FormDescription>
                                Price of your listing in dollars.
                            </FormDescription>
                            <FormMessage />
                            </FormItem>
                        )}
                    />
                    <FormField
                        control={form.control}
                        name="quantity"
                        render={({ field }) => (
                            <FormItem>
                            <FormLabel>Quantity</FormLabel>
                            <FormControl>
                                <Input {...field} required type="number"/>
                            </FormControl>
                            <FormDescription>
                                How many of this product do you have in stock?
                            </FormDescription>
                            <FormMessage />
                            </FormItem>
                        )}
                    />
                    <Button type="submit" className="mt-3 w-full">Create Listing</Button>
                </form>
            </Form>
        </DialogContent>
    </Dialog>
    </div>
  );
};

export default HomePage;
