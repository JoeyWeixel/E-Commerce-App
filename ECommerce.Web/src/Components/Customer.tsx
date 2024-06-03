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

type CardProps = {
    customer: CustomerType,
    onClick: (click: CustomerType) => void
    loadData: () => void
}

const CustomerCard: React.FC<CardProps> = ({ customer, onClick, loadData }) => {
    const deleteCustomer = (event: React.MouseEvent<HTMLButtonElement, MouseEvent>) => {
        event.stopPropagation();
        fetch(`https://localhost:7249/customers/${customer.id}`, 
            {
                headers: {
                    Accept: "*/*"
                },
                method: 'DELETE'
            }
        )
        .then(response => response.json)
        .then(() => loadData())
    };

    return (
    <div className='customer-card' onClick={() => onClick(customer)}>
        <img src={RealHFritz} alt='The real henry fritz'></img>
        <div className='info'>
            <p className='name'>{customer.contactInfo.name}</p>
            <p className="email">{customer.contactInfo.email}</p>
        </div>
        <button className='delete' onClick={(e) => deleteCustomer(e)}>Delete</button>
    </div>
    )
};

export default CustomerCard