import React, { Component } from 'react';
import ReactDOM from 'react-dom';
import { Route, BrowserRouter, Redirect, Switch } from "react-router-dom";
import './index.css';
import { parseJwt, usuarioAutenticado } from './services/auth';
import reportWebVitals from './reportWebVitals';

//Paginas:
import Home from './Pages/Home/Home';
import Login from './Pages/Login/Login';

const permissaoLogado = ({ component: Component }) => (
  <Route
    render={(props) =>
      usuarioAutenticado() ? (
        <Component {...props} />
      ) : (
        <Redirect to="/login" />
      )}
  />
);

const routing = (
  <BrowserRouter>
    <Switch>
      <Route exact path='/' component={Login} />
      <Route path='/Home' component={Home} />
      <Route path='/Login' component={Login}/>
    </Switch>
  </BrowserRouter>
);

ReactDOM.render(routing, document.getElementById('root'));

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
