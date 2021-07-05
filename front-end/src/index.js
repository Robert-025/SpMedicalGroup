import React, { Component } from 'react';
import ReactDOM from 'react-dom';
import { Route, BrowserRouter as Router, Switch, Redirect } from 'react-router-dom';
import { parseJwt, usuarioAutenticado } from './services/authentication';
 
import './index.css';

import App from './pages/home/App.js';
import NotFound from './pages/notFound/notFound';
import listarAdm from './pages/listarADM/listarADM'
import listarMedico from './pages/listarMedico/listarMedico'
import listarPaciente from './pages/listarPaciente/listarPaciente'
import Cadastrar from './pages/cadastro/cadastro'
import Login from './pages/login/login';

import reportWebVitals from './reportWebVitals';
import { parse } from 'json5';

const PermissaoAdm = ({ component : Component }) => {
  <Route 
    render = {props => 
      //Verifica se o usuário está logado e se ele é ADM
      usuarioAutenticado() && parseJwt.Role === "1" ? 
      //Se sim, renderiza de acordo com a rota solicitada e permitida
      <Component {...props}/> :
      //Se não, redireciona para login
      <Redirect to='login' /> 
    }
  />
}

const PermissaoPaciente = () => {
  <Route
    render = {props => 
      usuarioAutenticado() && parseJwt.Role === "2" ?
      <Component {...props} /> : <Redirect to='login' />
    }
  />
}

const routing = (
  <Router>
    <div>
      <Switch>
        <Route exact path="/" component={App} />
        <Route path="/listarAdm" component={listarAdm} />
        <Route path="/listarMedico" component={listarMedico} />
        <Route path="/listarPaciente" component={listarPaciente} />
        <Route  path="/cadastro" component={Cadastrar} />
        <Route path="/login" component={Login} />
        <Redirect to="/notFound" component={NotFound} />
        <Route path="/notFound" component={NotFound} />
      </Switch>
    </div>
  </Router>
)

ReactDOM.render(routing, document.getElementById('root'));

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
