import React from "react";
import { Link } from "react-router-dom";
import { Avatar, AvatarFallback, AvatarImage } from "@/Components/ui/avatar";
import {
  Sheet,
  SheetContent,
  SheetDescription,
  SheetHeader,
  SheetTitle,
  SheetTrigger,
} from "@/Components/ui/sheet";
import { Button } from "@/Components/ui/button";

import { useCustomer } from "@/Contexts/CustomerContext";
import RealHFritz from "@/assets/RealHenryFritz.jpeg";

const Header: React.FC = () => {
  const { currentCustomer } = useCustomer();
  return (
    <div className="flex items-center w-screen h-16 bg-gray-800">
      <div className="items-start">
        <Link to="/">
          <img
            className="w-16 ml-1 p-1 rounded-lg object-contain"
            src="https://media.licdn.com/dms/image/D5603AQFHz0FdYA9DqQ/profile-displayphoto-shrink_200_200/0/1694185994992?e=2147483647&v=beta&t=2UQTFQe-wXVnR3Pp41Yeo0Iva2lbzMiv0mSpuMzJvJM"
            alt="Website Logo"
          />
        </Link>
      </div>

      <div className="flex w-full m-auto justify-end items-center p-4 m-2">
        <Link to="orders">
          <Button className=" text-center align-middle bg-gray-800 hover:bg-gray-700">
            <span className="text-white text-sm font-bold">Orders</span>
          </Button>
        </Link>

        {!currentCustomer ? (
          <Link to="customers">
            <Button className="bg-gray-800 hover:bg-gray-700">
              <span className="text-white text-sm font-bold">Login</span>
            </Button>
          </Link>
        ) : (
          <>
            <span className="text-sm text-white font-bold text-center align-middle p-2">
              {currentCustomer.contactInfo.name}
            </span>
            <Avatar className="float-end mr-2">
              <Link to="customers">
                <AvatarImage src={RealHFritz} />
                <AvatarFallback>CN</AvatarFallback>{" "}
              </Link>
            </Avatar>
          </>
        )}

        <Sheet>
          <SheetTrigger>
            <Button className="text-sm text-white font-bold text-center align-middle bg-gray-800 hover:bg-gray-700">
              Cart
            </Button>
          </SheetTrigger>

          <SheetContent>
            <SheetHeader>
              <SheetTitle>
                <Link to="cart">
                  <span className="text-white font-bold">Go to Cart</span>
                </Link>
              </SheetTitle>
              <SheetDescription>Your cart is empty</SheetDescription>
            </SheetHeader>
          </SheetContent>
        </Sheet>
      </div>
    </div>
  );
};

export default Header;
