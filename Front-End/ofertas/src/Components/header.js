import React from "react";
import { Link } from 'react-router-dom';
import logo from '../../assets/img/Logotipo.png';
import usuario from '../assets/img/Usuario.png';
import carrinho from '../assets/img/Carrinho.png';

export const Cabecalho = () => {
    
    return(
        <header className="cabecalhoPrincipal">
            <div className="container">
                <Link to="/">
                    <img src={logo} alt="Logo do Site" />{' '}
                </Link>
                <Link to="/usuario">
                <img src={usuario} alt="Logo do Perfil" />{' '}
                </Link>
                <Link to="/perfil">
                <img src={carrinho} alt="Carrinho" />{' '}
                </Link>
            </div>
        </header>
    )
}

export default Cabecalho;