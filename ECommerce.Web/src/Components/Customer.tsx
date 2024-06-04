import React from 'react';
import RealHFritz from "../assets/RealHenryFritz.jpeg";
import { Avatar, AvatarImage } from './ui/avatar';
import {
    Card,
    CardContent,
  } from "./ui/card";
import { Button } from "./ui/button"
import { AvatarFallback } from '@radix-ui/react-avatar';
import { Label } from './ui/label';
import { Separator } from './ui/separator';


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
        <Card className='w-full my-2 h-16'>
            <CardContent className='flex items-center justify-between gap-5 py-2 h-full'>
                <Avatar className="justify-self-start">
                    <AvatarImage src={RealHFritz} alt='The real henry fritz'></AvatarImage>
                    <AvatarFallback>Holy Fwick</AvatarFallback>
                </Avatar>
                <Label className='text-xl w-1/3'>{customer.contactInfo.name}</Label>
                <Separator orientation='vertical'></Separator>
                <div className='justify-self-end flex justify-between gap-10 -ml-8'>
                    <Button onClick={() => onClick(customer)}>Sign In</Button>
                    <Button className='delete' onClick={() => deleteCustomer()} variant={"destructive"}>Delete</Button>
                </div>
            </CardContent>
        </Card>
    )
};

export default CustomerCard