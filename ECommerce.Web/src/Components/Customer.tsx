import React from 'react';
import RealHFritz from "../assets/RealHenryFritz.jpeg";


export type ContactInfoType = {
    name: string,
    email: string,
    address: string,
    phoneNumber: string
  }
export type CustomerType = {
    id: number,
    contactInfo: ContactInfoType
  }

interface CardProps {
    customer: CustomerType,
    onClick: (click: CustomerType) => void
}

const CustomerCard: React.FC<CardProps> = ({ customer, onClick }) => {
    return (
    <div className='customer-card hover:customer-hover' onClick={() => onClick(customer)}>
        <img src={RealHFritz} alt='The real henry fritz'></img>
        <div className='info'>
            <p className='name'>{customer.contactInfo.name}</p>
            <p className="email">{customer.contactInfo.email}</p>
        </div>
    </div>
    )
};

export default CustomerCard