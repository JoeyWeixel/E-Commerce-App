"use client"
 
import { zodResolver } from "@hookform/resolvers/zod";
import { useForm } from "react-hook-form";
import { z } from "zod";
import CustomerCard from "../Components/Customer";
import { CustomerType } from "../Components/Customer";
import "../Styles/CustomerStyle.css"
import { useState, useEffect } from "react";
import {
    Form,
    FormControl,
    FormDescription,
    FormField,
    FormItem,
    FormLabel,
    FormMessage,
} from "@/Components/ui/form";
import { Button } from "@/Components/ui/button";
import { Input } from "@/Components/ui/input";
import { ScrollArea } from "@/Components/ui/scroll-area"
import {
    Dialog,
    DialogContent,
    DialogHeader,
    DialogTitle,
    DialogTrigger,
  } from "@/Components/ui/dialog"

type CustomerPageProps = {
    updateCustomer: (c: CustomerType) => void
}

const CustomerPage: React.FC<CustomerPageProps> = ({ updateCustomer }) => {
    const [customers, setCustomers] = useState<CustomerType[]>([]);

    const formSchema = z.object({
        name: z.string().min(3, {
            message: "Name must be at least 3 characters.",
        }),
        address: z.string(),
        phone: z.string().length(10, {
            message: "Phone number must be 10 digits in length.",
        }),
        email: z.string()
    })

    const loadData = () => {
        fetch('https://localhost:7249/customers') 
        .then(response => {
          if (!response.ok) {
            throw new Error('Network response was not ok');
          }
          return response.json();
        })
        .then(data => setCustomers(data))
        .catch(error => console.error('Error fetching customers:', error));
    }
    
    const form = useForm<z.infer<typeof formSchema>>({
        resolver: zodResolver(formSchema),
        defaultValues: {
            name: "",
            email: "",
            phone: "",
            address: "",
        },
    })

    const onSubmit = (values: z.infer<typeof formSchema>) => {
        fetch("https://localhost:7249/customers", 
            {
                body: JSON.stringify({
                    contactInfo: {
                        name: values.name,
                        email: values.email,
                        phoneNumber: values.phone,
                        address: values.address
                    }
                }),
                headers: {
                    Accept: "*/*", 
                    "Content-Type": "application/json"
                },
                method: "POST"
            })
            .then(response => response.json)
            .then(() => loadData())
    };

    useEffect(() => {
        loadData();
      }, []);

    return (

        <div className="flex flex-col place-items-center">
            <ScrollArea className="max-w-screen-sm max-h-md min-w-md">
                {customers.map(customer => 
                    <CustomerCard customer={customer} onClick={updateCustomer} loadData={loadData} key={customer.id} />
                )}
            </ScrollArea>
            <Dialog>
                <DialogTrigger asChild>
                    <Button variant="outline">Sign Up</Button>
                </DialogTrigger>
                <DialogContent>
                    <DialogHeader>
                        <DialogTitle>Sign Up</DialogTitle>
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
                                        <Input placeholder="Name" {...field} />
                                    </FormControl>
                                    <FormDescription>
                                        This is your public display name.
                                    </FormDescription>
                                    <FormMessage />
                                    </FormItem>
                                )}
                            />
                            <FormField
                                control={form.control}
                                name="email"
                                render={({ field }) => (
                                    <FormItem>
                                    <FormLabel>Email</FormLabel>
                                    <FormControl>
                                        <Input placeholder="Email" {...field} />
                                    </FormControl>
                                    <FormDescription>
                                        How we will contact you about account information.
                                    </FormDescription>
                                    <FormMessage />
                                    </FormItem>
                                )}
                            />
                            <FormField
                                control={form.control}
                                name="address"
                                render={({ field }) => (
                                    <FormItem>
                                    <FormLabel>Address</FormLabel>
                                    <FormControl>
                                        <Input placeholder="Address" {...field} />
                                    </FormControl>
                                    <FormDescription>
                                        Where we will ship your orders.
                                    </FormDescription>
                                    <FormMessage />
                                    </FormItem>
                                )}
                            />
                            <FormField
                                control={form.control}
                                name="phone"
                                render={({ field }) => (
                                    <FormItem>
                                    <FormLabel>Phone</FormLabel>
                                    <FormControl>
                                        <Input placeholder="(000) 000-0000" {...field} />
                                    </FormControl>
                                    <FormDescription>
                                        For text updates about order status.
                                    </FormDescription>
                                    <FormMessage />
                                    </FormItem>
                                )}
                            />
                            <Button type="submit">Create Account</Button>
                        </form>
                    </Form>
                </DialogContent>
            </Dialog>
        </div>
    );
};


export default CustomerPage
