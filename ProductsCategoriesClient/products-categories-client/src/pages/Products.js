import React, {lazy} from "react";
import axios from "axios";
import {DEFAULT_URL} from "../http/urls"

const NavBar = lazy(() => import('../components/NavBar'));
const ProductsWithCategoryNameTable = lazy(() => import('../components/ProductsWithCategoryNameTable'));

const url = DEFAULT_URL + "/product/products-list-with-category";

class Products extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            error: null,
            isLoaded: false,
            products: []
        };
    }
    
    componentDidMount() {
      const headers = { 'Content-Type': 'application/json' };

      axios.get(url, {headers})
          .then(response => (
              this.setState({ 
                  isLoaded: true,
                  products: response.data.data 
              })
          ))
          .catch(error => {
              this.setState({ 
                  isLoaded: true, 
                  error: error.message
              });
              console.error('There was an error!', error);
          }); 
    }

    render() {
        const { error, isLoaded, products} = this.state;
        
        if (error) {
            return <div>Ошибка!</div>;
        } else if (!isLoaded) {
            return <div>Загрузка...</div>;
        } else {
          return(
              <div>
                  <NavBar />
                  <div className="center">
                    <ProductsWithCategoryNameTable 
                      products={products} 
                    />
                  </div>
              </div>
          );
        }
    }
}

export default Products;