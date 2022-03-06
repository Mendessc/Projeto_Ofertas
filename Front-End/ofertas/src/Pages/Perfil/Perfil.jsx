import { Component } from 'react';
import { useState, useEffect } from 'react';
import axios, { Axios } from 'axios';
import { parseJwt, usuarioAutenticado } from '../../services/auth';
import { Link, useNavigate } from 'react-router-dom';
import { render } from '@testing-library/react';

//CSS:
import '../../assets/css/home.css';
import '../../assets/css/perfil.css';

//Componentes:
import Cabecalho from "../../Components/header";
import Rodape from "../../Components/footer";

export default function Perfil() {
    const [listaReservas, setListaReservas] = useState([]);
    const [listaReservasProprias, setReservasProprias] = useState([]);
    const [consumirdorLogado, setConsumidorLogado] = useState({});
    const [counter, setCounter] = useState(0);

    function buscarConsumidor() {
        axios('http://localhost:5000/api/Consumidor/' + parseJwt().jti)
            .then(resposta => {
                if (resposta.status == 200) {
                    setConsumidorLogado(resposta.data);
                    setCounter(1);
                }
            })
            .catch(erro => console.log(erro))
    }

    function listarReservasProprias() {
        axios('http://localhost:5000/api/Reserva/Minhas?id=' + consumirdorLogado.idConsumidor, {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
            .then(resposta => {
                if (resposta.status == 200) {
                    setReservasProprias(resposta.data);
                    console.log(resposta.data);
                }
            })
            .catch(erro => console.log(erro));
    }

    function desfazerReserva(idReserva) {

        if (window.confirm("Deseja mesmo desfazer tal reserva?")) {
            axios.delete('http://localhost:5000/api/Reserva?id=' + idReserva, {
                headers: {
                    'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
                }
            })
                .then(resposta => {
                    if (resposta.status == 204) {
                        alert("reserva desfeita com sucesso");
                        listarReservasProprias();
                    }
                })
                .catch(erro => console.log(erro));
        }
    }

    //useEffect(listarReservasProprias, []);
    useEffect(listarReservasProprias, [counter < 1])
    useEffect(buscarConsumidor, []);

    return (

        <div>
            <Cabecalho />
            <h1 className="container tituloh1">Perfil de Usuário</h1>
            <div className="container dadosDoUsuario">
                <p>Email: {parseJwt().email}</p>
                <p>Nome: {consumirdorLogado.nome}</p>
                <p>CPF: {consumirdorLogado.cpf}</p>
                <p>Telefone: {consumirdorLogado.tefelone}</p>
            </div>
            <h1 className='container tituloh1'>Suas Reservas:</h1>
            <div className="container">
                {listaReservasProprias.map((reserva) => {
                    return (
                        <div className="cadaProdutoListado_Home" key={reserva.idReserva}>
                            <div className="imgProduto_Home">
                                <img src={"http://localhost:5000/img/" + reserva.idProdutoNavigation.imagemProduto} alt="" />
                            </div>
                            <div className="dadosProdutos_Home">
                                <div className="dadosProduto_Home">
                                    <p>{reserva.idProdutoNavigation.nomeProduto}</p>
                                </div>
                                <div className="areaPrecoLevar_Home">
                                    <span className="preco_home" >R$ {reserva.idProdutoNavigation.preco}</span>
                                    <button className='botaoDesfazerReserva' onClick={() => desfazerReserva(reserva.idReserva)}>Desfazer Reserva</button>
                                </div>
                            </div>
                            <div className="areaValidade">
                                <span>Vence em {Intl.DateTimeFormat("pt-br", {
                                    year: 'numeric', month: 'numeric', day: 'numeric',
                                }).format(new Date(reserva.idProdutoNavigation.dataValidade))
                                }</span>
                            </div>
                        </div>
                    )
                })
                }
            </div>
            <Rodape />
        </div>

    );
}