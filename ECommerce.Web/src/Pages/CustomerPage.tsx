import { useForm, SubmitHandler } from "react-hook-form";
import CustomerCard from "../Components/Customer";
import { CustomerType } from "../Components/Customer";
import "../Styles/CustomerStyle.css"

type CustomerPageProps = {
    customers: CustomerType[],
    updateCustomer: (c: CustomerType) => void
}

type FormValues = {
    name: string
    address: string
    phone: string
    email: string
}

const CustomerPage: React.FC<CustomerPageProps> = ({ customers, updateCustomer }) => {


    const { register, handleSubmit } = useForm<FormValues>();
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
            .then(response => response.json())
            .then(json => console.log(json));
    };


    {/*
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
    */}

/*     const postCustomer = (e: React.SyntheticEvent<HTMLFormElement>) => {
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
                    Accept: "*\/*", 
                    "Content-Type": "application/json"
                },
                method: "POST"
            })
            .then(response => response.json())
            .then(json => console.log(json));
        };
     */
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
