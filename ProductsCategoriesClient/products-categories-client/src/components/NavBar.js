import React from 'react';
import { Link } from 'react-router-dom';

class NavBar extends React.Component {    
    render() {
        return(
            <div className='navbar'>
                <ul className='menu'>
                    <li><Link to="/">Товары</Link></li>
                    <li><Link to="/products-categories">Товары и категории</Link></li>
                </ul>
            </div>
        );
    }
}

export default NavBar;