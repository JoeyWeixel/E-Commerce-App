import React from 'react';


interface ContactInfoType {
    name: string,
    email: string,
    address: string,
    phoneNumber: string
}
interface CustomerType {
    id: number,
    contactInfo: ContactInfoType
}

const CustomerCard: React.FC<CustomerType> = (customer: CustomerType) => {
    return (
    <div className='customer-card'>
        <img src='../assets/RealHenryFritz.jpeg' alt='The real henry fritz'></img>
        <div className='info'>
            <p className='name'>{customer.contactInfo.name}</p>
            <p className="email">{customer.contactInfo.email}</p>
        </div>
    </div>
    )
};

export default CustomerCard