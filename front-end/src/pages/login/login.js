import React, { Component } from 'react';
import { Link } from 'react-router-dom';

import '../../assets/css/login.css'

import Header from '../../components/header/header';
import Footer from '../../components/footer/footer';

export default class Login extends Component{
    constructor(props){
        super(props);
        this.state = {
            email : '',
            senha : ''
        }
    }    

    componentDidMount(){

    }

    atualizarStateX = () => {

    }

    render(){
        return(
            <div className="body">
            <Header />

            <main className='main-login'>
                <section className="informacoes alinhando-centro">
                    <h2>Login</h2>

                    {/* Chama a função de login quando o botão é pressionado */}

                    <form className="dados" onSubmit={}>
                        <div className="email">
                            <h3>E-mail</h3>
                            <div className="input">
                                <input 
                                    type="email" 
                                    //Define que o input email recebe o valor do state email
                                    name="email"
                                    value={this.state.email}
                                    onChange={this.atualizarStateX} />
                            </div>
                        </div>
                        <div className="senha">
                            <h3>Senha</h3>
                            <div className="input">
                                <input 
                                    type="password" 
                                    //Define que o input senha recebe o valor do state senha
                                    name="senha"
                                    value={this.state.senha}
                                    onChange={this.atualizarStateX} />
                            </div>
                        </div>
                        <button type="submit">Entrar</button>
                    </form>

                </section>
            </main>

            <Footer />
            </div>
        )
    }
}