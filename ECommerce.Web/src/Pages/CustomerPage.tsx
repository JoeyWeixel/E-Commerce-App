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
  } from "@/Components/ui/dialog";
import { Label } from "@/Components/ui/label";

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

        <div className="flex flex-col justify-start gap-4 h-full pt-20">
            <Label className="text-4xl w-9/12 mx-auto underline">Select User</Label>
            <ScrollArea className="w-9/12 mx-auto h-1/2 border p-4 rounded-md">
                {customers.map(customer => 
                    <CustomerCard customer={customer} onClick={updateCustomer} loadData={loadData} key={customer.id} />
                )}
            </ScrollArea>
            <Dialog>
                <DialogTrigger asChild>
                    <Button variant="outline"  className="h-16 mx-auto w-3/4 text-center text-xl hover:cursor-pointer bg-primary border-primary text-white"><u>Sign Up</u></Button>
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
                                        <Input placeholder="Name" {...field} required type="text"/>
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
                                        <Input placeholder="Email" {...field} required type="email"/>
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
                                        <Input placeholder="Address" {...field} required type="text"/>
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
                                        <Input placeholder="(000) 000-0000" {...field} required type="tel"/>
                                    </FormControl>
                                    <FormDescription>
                                        For text updates about order status.
                                    </FormDescription>
                                    <FormMessage />
                                    </FormItem>
                                )}
                            />
                            <Button type="submit" className="mt-3 w-full">Create Account</Button>
                        </form>
                    </Form>
                </DialogContent>
            </Dialog>
        </div>
    );
};


export default CustomerPage
