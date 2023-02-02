import React, {Suspense, lazy} from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';

const Products = lazy(() => import('./pages/Products'));
const ProductsCategories = lazy(() => import('./pages/ProductsCategories'));

class App extends React.Component {
  render() {
    return(
      <BrowserRouter>
      <Suspense fallback={<div>Загрузка...</div>}>
        <Routes>
            <Route path='/' exact element={<Products/>} />
            <Route path='/products-categories' exact element={<ProductsCategories/>}/>
          </Routes>
      </Suspense>
    </BrowserRouter>
    );
  }
}

export default App;
