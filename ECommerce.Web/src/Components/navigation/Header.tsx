import React from "react";
import "../Styles/HeaderStyle.css";
import SearchIcon from "@mui/icons-material/Search";
import ShoppingBasketIcon from "@mui/icons-material/ShoppingBasket";
import { Link } from "react-router-dom";
import { Button } from "@/Components/ui/button";
import { useCustomer } from "@/Contexts/CustomerContext";

const Header: React.FC = () => {
  const { currentCustomer } = useCustomer();

  return (
    <div className="header">
      <Link to="/">
        <img
          className="header__logo"
          src="https://media.licdn.com/dms/image/D5603AQFHz0FdYA9DqQ/profile-displayphoto-shrink_200_200/0/1694185994992?e=2147483647&v=beta&t=2UQTFQe-wXVnR3Pp41Yeo0Iva2lbzMiv0mSpuMzJvJM"
          alt="Logo"
        />
      </Link>

      <div className="header__search">
        <input className="header__searchInput" type="text" />
        <SearchIcon className="header__searchIcon" />
      </div>

      <div className="header__nav">
        <div className="header__option">
          <span className="header__optionLineOne">
            {"Welcome " + (!currentCustomer ? "Guest" : currentCustomer.id)}
          </span>
          <Link to="/customers">
            <span className="header__optionLineTwo"> Switch Account</span>
          </Link>
        </div>

        <div className="header__option">
          <Link to="/orders">
            <span className="header__optionLineThree">Orders</span>
          </Link>
        </div>

        <Button variant="outline">
          <div className="header__optionBasket">
            <Link to="/cart">
              <ShoppingBasketIcon />
            </Link>
          </div>
        </Button>
      </div>
    </div>
  );
};

export default Header;
