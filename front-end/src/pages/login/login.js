import { Component } from 'react';
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

    render(){
        return(
            <div className="body">
            <Header />

            <main className='main-login'>
                <section className="informacoes alinhando-centro">
                    <h2>Login</h2>
                    <div className="dados">
                        <div className="email alinhando-centro">
                            <h3>E-mail</h3>
                            <div className="input">
                                <input type="email" name="" id="" />
                            </div>
                        </div>
                        <div className="senha alinhando-centro">
                            <h3>Senha</h3>
                            <div className="input">
                                <input type="password" name="" id="" />
                            </div>
                        </div>
                        <button type="submit">Entrar</button>
                    </div>
                </section>
            </main>

            <Footer />
            </div>
        )
    }
}