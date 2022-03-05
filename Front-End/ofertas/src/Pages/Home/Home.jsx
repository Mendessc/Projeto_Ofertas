import { Component } from 'react';
import { useState, useEffect } from 'react';
import axios, { Axios } from 'axios';
import { parseJwt, usuarioAutenticado } from '../../services/auth';
import { Link, useNavigate } from 'react-router-dom';
import { render } from '@testing-library/react';

export default function Home() {
    const [listaProdutos, setListaProdutos] = useState([]);
    const [listaConsumidores, setListaConsumidores] = useState([]);
    const [reservando, setReservando] = useState(false);
    const [idConsumidor, setIdConsumidor] = useState();

    let history = useNavigate();

    function ListarProdutos() {
        axios('http://localhost:5000/api/Produto')
            .then(resposta => {
                if (resposta.status === 200) {
                    console.log(resposta.data);
                    setListaProdutos(resposta.data);
                    console.log(listaProdutos);
                }
            })
            .catch(erro => console.log(erro))
    }

    function ReservarProduto(produto) {

        if (usuarioAutenticado() && parseJwt().role === '2') {
            setReservando(true);
            axios('http://localhost:5000/api/Consumidor')
                .then(resposta => {
                    if (resposta.status === 200) {
                        console.log(resposta.data);
                        // console.log(parseJwt());
                        resposta.data.map((consumidor) => {
                            if (consumidor.idUsuario == parseJwt().jti) {
                                setIdConsumidor(consumidor.idConsumidor);
                                console.log('idConsumidor encontrado');
                                axios.post('http://localhost:5000/api/Reserva', {
                                    idConsumidor: idConsumidor,
                                    idProduto: produto.idProduto
                                })
                                    .then(resposta => {
                                        if (resposta.status == 200) {
                                            console.log('produto reservado');
                                            setReservando(false);
                                            ListarProdutos();
                                        }
                                    })
                            } else {
                                console.log('idConsumidor nao encontrado');
                            }
                        })
                    }
                })

        } else {
            console.log('nao e consumidor, sem autorizacao para reservar');
            history('/Login');
        }
    }

    useEffect(ListarProdutos, []);

    return (
        <div>
            {listaProdutos.map((produto) => {
                return (
                    <div key={produto.idProduto}>
                        <h1>Botao reservar</h1>
                        {reservando ? null : <button onClick={() => ReservarProduto(produto)}></button>}
                    </div>
                )
            })}
        </div>
    );
}
