import CustomerCard from "../Components/Customer"
import { CustomerType } from "../Components/Customer";
import "../Styles/CustomerStyle.css"

type CustomerPageProps = {
    customers: CustomerType[]
}

const CustomerPage: React.FC<CustomerPageProps> = ({ customers }) => {


    return (
        <>
            <div className="customer-page">
                {customers.map(x => 
                    <CustomerCard customer={x} />
                )}
            </div>
        </>
    );
};

export default CustomerPage
