import React from 'react';
import RealHFritz from "@/assets/RealHenryFritz.jpeg";
import { Avatar, AvatarImage } from './ui/avatar';
import {
    Card,
    CardContent,
  } from "./ui/card";
import { Button } from "./ui/button"
import { AvatarFallback } from '@radix-ui/react-avatar';
import { Label } from './ui/label';
import { Separator } from './ui/separator';
import {
    Accordion,
    AccordionContent,
    AccordionItem,
    AccordionTrigger,
  } from "@/Components/ui/accordion"


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
        <Card className='w-full my-2 min-h-16 max-h-fit'>
            <CardContent className='flex items-center gap-5 py-2 h-full w-full'>
                <Accordion type="single" collapsible className="w-full">
                    <AccordionItem value="item-1" className="border-none w-full">
                        <AccordionTrigger className='flex gap-16'>
                            <Avatar className="justify-self-start size-14">
                                <AvatarImage src={RealHFritz} alt='The real henry fritz'></AvatarImage>
                                <AvatarFallback>Holy Fwick</AvatarFallback>
                            </Avatar>
                            <Label className='text-xl'>{customer.contactInfo.name}</Label>
                        </AccordionTrigger>
                        <AccordionContent className='flex justify-between items-center border-t-2 pt-2'>
                            <div className="flex flex-col gap-2">
                                <Label className='text-lg'>Email: {customer.contactInfo.email}</Label>
                                <Label className='text-lg'>Phone: {customer.contactInfo.phoneNumber}</Label>
                                <Label className='text-lg'>Address: {customer.contactInfo.address}</Label>
                            </div>
                            <div className='ml-auto flex justify-between gap-10 items-center h-full'>
                                <Separator orientation='vertical' className='h-16 ml-auto'></Separator>
                                <Button onClick={() => onClick(customer)}>Sign In</Button>
                                <Button className='delete' onClick={() => deleteCustomer()} variant={"destructive"}>Delete</Button>
                            </div>
                        </AccordionContent>
                    </AccordionItem>
                </Accordion>
            </CardContent>
        </Card>
    )
};

export default CustomerCard