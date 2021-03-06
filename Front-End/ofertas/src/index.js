import React, { Component } from 'react';
import { render } from "react-dom";
import { Route, BrowserRouter, Routes, Navigate } from "react-router-dom";
import './index.css';
import { parseJwt, usuarioAutenticado } from './services/auth';
import reportWebVitals from './reportWebVitals';

//Paginas:
import Home from './Pages/Home/Home';
import Login from './Pages/Login/Login';
import CadastroProduto from './Pages/CadastroProduto/CadastroProduto';
import CadastroUsuario from './Pages/CadastroUsuário/CadastroUsuario';
import Perfil from './Pages/Perfil/Perfil';

const permissaoLogado = ({ element: Component }) => (
  <Route
    render={(props) =>
      usuarioAutenticado() ? (
        <Component {...props} />
      ) : (
        <Navigate to="/Login" />
      )}
  />
);

// const routing = (
//   <BrowserRouter>
//     <Routes>
//       <Route exact path='/' component={Login} />
//       <Route path='/Home' component={Home} />
//       <Route path='/Login' component={Login} />
//     </Routes>
//   </BrowserRouter>
// );

// ReactDOM.render(routing, document.getElementById('root'));

render(
  <BrowserRouter>
    <Routes>
      <Route exact path='/' element={<Login />} />
      <Route path='/Home' element={<Home />} />
      <Route path='/Login' element={<Login />} />
      {
        usuarioAutenticado() && parseJwt().role === '3' ? <Route path='/CadastroProduto' element={<CadastroProduto />} /> : null
      }
      <Route path='/CadastroUsuario' element={<CadastroUsuario />} />
      {
        usuarioAutenticado() && parseJwt().role === '2' ? <Route path='/Perfil' element={<Perfil />}/> : null
      }
    </Routes>
  </BrowserRouter>,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
