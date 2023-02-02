import React from "react";

class ProductsWithCategoryNameTable extends React.Component {
    render() {
        const products = this.props.products;

        return(
            <table className="table">
                <thead>
                    <tr>
                        <th>Название</th>
                        <th>Цена</th>
                        <th>Кол-во</th>
                        <th>Категория</th>
                    </tr>
                </thead>
                <tbody>
                    {products.map(product => (
                        <tr key={product.id}>
                            <td>{product.name}</td>
                            <td>{product.price} руб</td>
                            <td>{product.amount}</td>
                            <td>{product.categoryName}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        );
    }
}

export default ProductsWithCategoryNameTable;