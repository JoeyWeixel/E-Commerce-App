// src/Components/Header.tsx
import React from 'react';
import '../Styles/HeaderStyle.css';
import SearchIcon from '@mui/icons-material/Search';
import ShoppingBasketIcon from '@mui/icons-material/ShoppingBasket';

interface HeaderProps {
  cartItemCount: number;
}

const Header: React.FC<HeaderProps> = ({ cartItemCount }) => {
  return (
    <div className="header">
      <img
        className="header__logo"
        src="https://media.licdn.com/dms/image/D5603AQFHz0FdYA9DqQ/profile-displayphoto-shrink_200_200/0/1694185994992?e=2147483647&v=beta&t=2UQTFQe-wXVnR3Pp41Yeo0Iva2lbzMiv0mSpuMzJvJM"
        alt="Logo"
      />

      <div className="header__search">
        <input className="header__searchInput" type="text" />
        <SearchIcon className="header__searchIcon" />
      </div>

      <div className="header__nav">
        <div className="header__option">
          <span className="header__optionLineOne">Hello Guest</span>
          <span className="header__optionLineTwo">Sign In</span>
        </div>

        <div className="header__option">
          <span className="header__optionLineOne">Returns</span>
          <span className="header__optionLineTwo">& Orders</span>
        </div>

        <div className="header__optionBasket">
          <ShoppingBasketIcon />
          <span className="header__optionLineTwo header__basketCount">{cartItemCount}</span>
        </div>
      </div>
    </div>
  );
};

export default Header;