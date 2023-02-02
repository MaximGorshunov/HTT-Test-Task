import React from "react";

class CategoryWithProductsListTable extends React.Component {
    render() {
        const name = this.props.name;
        const products = this.props.products;

        return(
            <table className="table">
                <caption>{name}</caption>
                <thead>
                    <tr>
                        <th>Название</th>
                        <th>Цена</th>
                        <th>Кол-во</th>
                    </tr>
                </thead>
                <tbody>
                    {products.map(product => (
                        <tr key={product.id}>
                            <td>{product.name}</td>
                            <td>{product.price} руб</td>
                            <td>{product.amount}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        );
    }
}

export default CategoryWithProductsListTable;