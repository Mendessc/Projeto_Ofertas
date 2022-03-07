import React from "react";
import { Link } from 'react-router-dom';
import logo from '../assets/img/Logotipo.png';
import usuario from '../assets/img/Usuario.png';
import carrinho from '../assets/img/Carrinho.png';
import '../assets/css/estilo.css'
import { parseJwt, usuarioAutenticado } from '../services/auth';

export const Cabecalho = () => {

    return (
        <header className="container_header">
            <div className="div_header">
                <div className="bloco_logo">
                    <Link to="/Home">
                        <img src={logo} alt="Logo do Site" />{' '}
                    </Link>
                </div>
                <div className="bloco_links">

                    {
                        usuarioAutenticado() && parseJwt().role === '2' ? <Link to="/Perfil"><img src={usuario} alt="Logo do Perfil" />{' '}</Link> : null
                    }
                    {
                        usuarioAutenticado() && parseJwt().role === '2' ? <Link to="/Perfil"><img src={carrinho} alt="Carrinho" />{' '}</Link> : null
                    }

                </div>
            </div>
        </header >
    )
}

export default Cabecalho;