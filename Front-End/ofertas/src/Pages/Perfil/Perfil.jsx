import { Component } from 'react';
import { useState, useEffect } from 'react';
import axios, { Axios } from 'axios';
import { parseJwt, usuarioAutenticado } from '../../services/auth';
import { Link, useNavigate } from 'react-router-dom';
import { render } from '@testing-library/react';

//Componentes:
import Cabecalho from "../../Components/header";
import Rodape from "../../Components/footer";

export default function Perfil() {
    const [listaReservas, setListaReservas] = useState([]);
    const [listaReservasProprias, setReservasProprias] = useState([]);

    function listarReservas() {
        if (usuarioAutenticado() && parseJwt().role === '2') {
            axios('http://localhost:5000/api/Reserva')
                .then(resposta => {
                    if (resposta.status === 200) {
                        console.log(resposta.data);
                        setListaReservas(resposta.data);
                        listaReservas.map((reserva) => {
                            if (reserva.idUsuario == parseJwt().jti) {
                                setReservasProprias(reserva);
                                console.log(listaReservasProprias);
                            }
                        });
                    }
                });
        }
    }

    function desfazerReserva() {

    }

    useEffect(listarReservas, []);

    return (

        <div>
            <Cabecalho />
            <Rodape />
        </div>

    );
}