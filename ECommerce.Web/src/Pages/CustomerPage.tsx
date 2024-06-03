import { useForm, SubmitHandler } from "react-hook-form";
import CustomerCard from "../Components/Customer";
import { CustomerType } from "../Components/Customer";
import "../Styles/CustomerStyle.css"
import { useState, useEffect } from "react";

type CustomerPageProps = {
    updateCustomer: (c: CustomerType) => void
}

type FormValues = {
    name: string
    address: string
    phone: string
    email: string
}

const CustomerPage: React.FC<CustomerPageProps> = ({ updateCustomer }) => {
    const [customers, setCustomers] = useState<CustomerType[]>([]);

    const { register, handleSubmit } = useForm<FormValues>();

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

    const onSubmit: SubmitHandler<FormValues> = (data) => {
        fetch("https://localhost:7249/customers", 
            {
                body: JSON.stringify({
                    contactInfo: {
                        name: data.name,
                        email: data.email,
                        phoneNumber: data.phone,
                        address: data.address
                    }
                }),
                headers: {
                    Accept: "*/*", 
                    "Content-Type": "application/json"
                },
                method: "POST"
            })
            .then(() => loadData())
    };

    useEffect(() => {
        // Fetch customers from the API
        loadData();
      }, []);

    return (
        <>
            <div className="customer-page">
                <div className="card-holder">
                    {customers.map(x => 
                        <CustomerCard customer={x} onClick={updateCustomer} />
                    )}
                </div>
            </div>
            <form onSubmit={handleSubmit(onSubmit)} >
                <title>Add A Customer</title>

                <label>Name:
                <input type="text" {...register("name")} required />
                </label>

                <label>Email:
                <input type="email" {...register("email")} required />
                </label>

                <label>Address:
                <input type="text" {...register("address")} required />
                </label>

                <label>Phone Number:
                <input type="tel" {...register("phone")} required />
                </label>

                <button type="submit">Add Customer</button>
            </form>
        </>
    );
};

export default CustomerPage
