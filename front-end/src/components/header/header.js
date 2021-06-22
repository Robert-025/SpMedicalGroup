import React from 'react';
import Logo from '../../assets/img/Logo.png';
import { Link } from 'react-router-dom';

export default function Header(){
    return(
    <header>
        <div className="content-cabecalho">
            <div className="esquerdo-header">
                <Link to='/'><img src={Logo} alt="Logo do Sp Medical Group" /></Link>
                <Link to='/'>SP Medical<br/>Group</Link>
            </div>
            
            <div className="direito-header">
                <input type="search" name="" id="" />
                <nav className="links-cabecalho">
                    <Link to='/'>Início</Link>
                    <Link to='/listar'>Consultas</Link>
                    <Link to='/usuario'>User</Link>
                </nav>
            </div>
        </div>
    </header>
    );
}