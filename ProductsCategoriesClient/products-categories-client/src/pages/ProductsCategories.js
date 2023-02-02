import React, {lazy} from "react";
import axios from "axios";
import {DEFAULT_URL} from "../http/urls"

const NavBar = lazy(() => import('../components/NavBar'));
const CategoriesList = lazy(() => import('../components/CategoriesList'));
const CategoryWithProductsListTable = lazy(() => import('../components/CategoryWithProductsListTable'));

const url = DEFAULT_URL + "/category/categories-products-list";

class ProductsCategories extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            error: null,
            isLoaded: false,
            categories: [],
            categoriesId: []
        };

        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleInputChange = this.handleInputChange.bind(this);
    }

    componentDidMount() {
        const headers = { 'Content-Type': 'application/json' };

        axios.get(url, {headers})
            .then(response => (
                this.setState({ 
                    isLoaded: true,
                    categories: response.data.data 
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

    handleSubmit(event) {
        event.preventDefault();

        const categoriesId = this.state.categoriesId;

        const params = Object.values(categoriesId);
        const headers = { 'Content-Type': 'application/json' };
        
        if(categoriesId.length !== 0) { 
            axios.post(url, params, {headers})
            .then(response => (this.setState({ categories: response.data.data })))
            .catch(error => {
                this.setState({ error: error.message });
                console.error('There was an error!', error);
            });
        } else {
            axios.get(url, {headers})
            .then(response => (this.setState({ categories: response.data.data })))
            .catch(error => {
                this.setState({ error: error.message });
                console.error('There was an error!', error);
            });
        } 
    }

    handleInputChange(event) {
        const target = event.target;
        const value = target.value;

        var ids = this.state.categoriesId;

        if (ids.some(item => item === parseInt(value))) {
            ids = ids.filter(item => item !== parseInt(value));
        } else {
            ids.push(parseInt(value));
        }

        this.setState({
            categoriesId: ids
        });
    }

    render() {
        const { error, isLoaded, categories} = this.state;
        
        if (error) {
            return <div>Ошибка!</div>;
        } else if (!isLoaded) {
            return <div>Загрузка...</div>;
        } else {
            return(
                <div>
                    <NavBar />
                    <div className="center-row">
                        <CategoriesList 
                            onValueChange={this.handleInputChange}
                            onFormSubmit={this.handleSubmit}
                        />
                        <div>
                            {categories.map(category => (
                                <CategoryWithProductsListTable 
                                    key={category.id}
                                    name={category.name}
                                    products={category.products}
                                />
                            ))}
                        </div>
                    </div>
                </div>
            );
        }
    }
}

export default ProductsCategories;