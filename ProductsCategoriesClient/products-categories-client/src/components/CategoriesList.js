import React from "react";
import axios from "axios";
import {DEFAULT_URL} from "../http/urls"

const url = DEFAULT_URL + "/category/categories-list";

class CategoriesList extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            error: null,
            isLoaded: false,
            categories: []
        }
        this.handleSubmit = this.handleSubmit.bind(this);
        this.handleChange = this.handleChange.bind(this);
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
        this.props.onFormSubmit(event);
    }

    handleChange(event) {
        this.props.onValueChange(event)
    } 

    render(){
        const {error, isLoaded, categories} = this.state;

        if (error) {
            return <div>Ошибка!</div>;
        } else if (!isLoaded) {
            return <div>Загрузка...</div>;
        } else {
            return(
                <form onSubmit={this.handleSubmit} className="categories-list">
                    <ul>
                        {categories.map(category =>(
                            <li key={category.id}>
                                <label>
                                    {category.name}
                                    <input 
                                        type="checkbox" 
                                        value={category.id}
                                        onChange={this.handleChange}
                                    />
                                </label>
                            </li>
                        ))}
                    </ul>
                    <input type="submit" value="Показать"/>
                </form>
            );
        }
    }
}

export default CategoriesList;