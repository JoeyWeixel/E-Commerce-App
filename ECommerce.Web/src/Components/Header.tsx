import React from "react";
import ShoppingBasketIcon from "@mui/icons-material/ShoppingBasket";
import { Link } from "react-router-dom";
import { Avatar, AvatarFallback, AvatarImage } from "@/Components/ui/avatar";
import { Button } from "@/Components/ui/button";
import { useCustomer } from "@/Contexts/CustomerContext";
import RealHFritz from "../assets/RealHenryFritz.jpeg";

const Header: React.FC = () => {
  const { currentCustomer } = useCustomer();
  return (
    <div className="flex items-center w-screen h-16 bg-gray-800">
      <div className="float-start">
        <Link to="/">
          <img
            className="w-16 ml-1 p-1 rounded-lg object-contain"
            src="https://media.licdn.com/dms/image/D5603AQFHz0FdYA9DqQ/profile-displayphoto-shrink_200_200/0/1694185994992?e=2147483647&v=beta&t=2UQTFQe-wXVnR3Pp41Yeo0Iva2lbzMiv0mSpuMzJvJM"
            alt="Website Logo"
          />
        </Link>
      </div>

      <div className="flex text-white w-full m-auto justify-end">
        <div className="text-sm font-bold text-center align-middle leading-9 p-2">
          <Link to="orders">
            <span className="">Orders</span>
          </Link>
        </div>

        <div className="p-2">
          {!currentCustomer ? (
            <div className="">
              <Button className="bg-gray-800 hover:bg-gray-700 ">
                <Link to="customers">
                  <span className="">Login</span>
                </Link>
              </Button>
            </div>
          ) : (
            <div>
              <span className="text-sm font-bold text-center align-middle leading-9 p-2">
                {currentCustomer.id}
              </span>
              <Avatar className="float-end">
                <Link to="customers">
                  <AvatarImage src={RealHFritz} />
                  <AvatarFallback>CN</AvatarFallback>{" "}
                </Link>
              </Avatar>
            </div>
          )}
        </div>

        <div className="font-bold justify-items-end float-end leading-7 p-2 mr-4">
          <Link to="cart">
            <ShoppingBasketIcon />
          </Link>
        </div>
      </div>
    </div>
  );
};

export default Header;
