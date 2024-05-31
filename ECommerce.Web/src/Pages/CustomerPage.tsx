import { useState } from "react";
import CustomerCard from "../Components/Customer"
import { CustomerType } from "../Components/Customer";
import "../Styles/CustomerStyle.css"

type CustomerPageProps = {
    customers: CustomerType[],
    updateCustomer: (c: CustomerType) => void
}

const CustomerPage: React.FC<CustomerPageProps> = ({ customers, updateCustomer }) => {


    const [name, setName] = useState<string>("");
    const [address, setAddress] = useState<string>("");
    const [phone, setPhone] = useState<string>("0000000000");
    const [email, setEmail] = useState<string>("");


    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        e.preventDefault();
        const title = e.target.title;
        switch (title){
            case 'name':
                setName(e.target.value);
                break;
            case 'address':
                setAddress(e.target.value);
                break;
            case 'phone':
                setPhone(e.target.value);
                break;
            case 'email':
                setEmail(e.target.value);
                break;
        }
        
    };

    const postCustomer = (e: React.SyntheticEvent<HTMLFormElement>) => {
        e.preventDefault();
        fetch("https://localhost:7249/customers", 
            {
                body: JSON.stringify({
                    contactInfo: {
                        name: name,
                        email: email,
                        phoneNumber: phone,
                        address: address
                    }
                }),
                headers: {
                    Accept: "*/*", 
                    "Content-Type": "application/json"
                },
                method: "POST"
            })
            .then(response => response.json())
            .then(json => console.log(json));
        };

    return (
        <>
            <div className="customer-page">
                <div className="card-holder">
                    {customers.map(x => 
                        <CustomerCard customer={x} onClick={updateCustomer} />
                    )}
                </div>
            </div>
            <form onSubmit={postCustomer} >
                <title>Add A Customer</title>

                <label htmlFor="name">Name:</label>
                <input title="name" type="text" value={name} onChange={handleChange} required />

                <label htmlFor="email">Email:</label>
                <input title="email" type="email" value={email} onChange={handleChange} required />

                <label htmlFor="address">Address:</label>
                <input title="address" type="text" value ={address} onChange={handleChange} required />

                <label htmlFor="phone">Phone Number:</label>
                <input title="phone" type="tel" value={phone} onChange={handleChange} required />

                <button type="submit">Add Customer</button>
            </form>
        </>
    );
};

export default CustomerPage
