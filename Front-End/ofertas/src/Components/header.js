import React from "react";
import { Link } from 'react-router-dom';
import logo from '../assets/img/Logotipo.png';
import usuario from '../assets/img/Usuario.png';
import carrinho from '../assets/img/Carrinho.png';
import '../assets/css/estilo.css'

export const Cabecalho = () => {

    return (
        <header className="container container_header">
            <div className="div_header">
                <div className="bloco_logo">
                    <Link to="/">
                        <img src={logo} alt="Logo do Site" />{' '}
                    </Link>
                </div>
                <div className="bloco_links">
                    <Link to="/usuario">
                        <img src={usuario} alt="Logo do Perfil" />{' '}
                    </Link>
                    <Link to="/perfil">
                        <img src={carrinho} alt="Carrinho" />{' '}
                    </Link>
                </div>
            </div>
        </header >
    )
}

export default Cabecalho;