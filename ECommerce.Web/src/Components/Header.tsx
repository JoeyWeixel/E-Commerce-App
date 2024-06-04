import React from "react";
import "../Styles/HeaderStyle.css";
import SearchIcon from "@mui/icons-material/Search";
import ShoppingBasketIcon from "@mui/icons-material/ShoppingBasket";
import { Link } from "react-router-dom";
import { CustomerType } from "./Customer";

type HeaderProps = {
  cartItemCount: number;
  customer: CustomerType | null;
};

const Header: React.FC<HeaderProps> = ({ cartItemCount, customer }) => {
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
            {"Welcome " + (!customer ? "Guest" : customer.contactInfo.name)}
          </span>
          <Link to="/customers">
            <span className="header__optionLineTwo"> Switch Account</span>
          </Link>
        </div>

        <div className="header__option">
          <Link to="/OrdersPage">
            <span className="header__optionLineThree">Returns & Orders</span>
          </Link>
        </div>

        <div className="header__optionBasket">
          <Link to="/cart">
            <ShoppingBasketIcon />
          </Link>
          <span className="header__basketCount">{cartItemCount}</span>
        </div>
      </div>
    </div>
  );
};

export default Header;
