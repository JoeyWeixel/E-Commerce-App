import CustomerCard from "../Components/Customer"
import { CustomerType } from "../Components/Customer";
import "../Styles/CustomerStyle.css"

type CustomerPageProps = {
    customers: CustomerType[],
    updateCustomer: (c: CustomerType) => void
}

const CustomerPage: React.FC<CustomerPageProps> = ({ customers, updateCustomer }) => {


    return (
        <>
            <div className="customer-page">
                {customers.map(x => 
                    <CustomerCard customer={x} onClick={updateCustomer} />
                )}
            </div>
        </>
    );
};

export default CustomerPage
