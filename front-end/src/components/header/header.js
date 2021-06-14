import React from 'react';
import Logo from '../../assets/img/Logo.png';

export default function Header(){
    return(
    <header>
        <div className="content-cabecalho">
            <div className="esquerdo-header">
                <img src={Logo} alt="Logo do Sp Medical Group" />
                <p>SP Medical<br/>Group </p>
            </div>
            
            <div className="direito-header">
                <input type="search" name="" id="" />
                <nav className="links-cabecalho">
                    <a href="#">Início</a>
                    <a href="#">Consultas</a>
                    <a href="#">User</a>
                </nav>
            </div>
        </div>
    </header>
    );
}