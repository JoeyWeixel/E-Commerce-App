import React from 'react';
import RealHFritz from "../assets/RealHenryFritz.jpeg";
import { Avatar, AvatarImage } from './ui/avatar';
import {
    Card,
    CardContent,
    CardFooter,
    CardHeader,
    CardTitle,
  } from "./ui/card";
import { Button } from "./ui/button"
import { AvatarFallback } from '@radix-ui/react-avatar';


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
    const deleteCustomer = () => {
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
        <Card>
            <CardHeader>
                <CardTitle>{customer.contactInfo.name}</CardTitle>
            </CardHeader>
            <CardContent>
                <Avatar>
                    <AvatarImage src={RealHFritz} alt='The real henry fritz'></AvatarImage>
                    <AvatarFallback>Holy Fwick</AvatarFallback>
                </Avatar>
                <p>{customer.contactInfo.email}</p>
                <p>{customer.contactInfo.phoneNumber}</p>
                <Button onClick={() => onClick(customer)}>Sign In</Button>
            </CardContent>
            <CardFooter>
                <Button className='delete' onClick={() => deleteCustomer()} variant={"destructive"}>Delete</Button>
            </CardFooter>
        </Card>
    )
};

export default CustomerCard