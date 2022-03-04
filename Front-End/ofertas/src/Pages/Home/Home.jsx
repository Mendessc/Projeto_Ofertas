import { Component } from 'react';
import { useState, useEffect } from 'react';
import axios, { Axios } from 'axios';
import { parseJwt, usuarioAutenticado } from '../../services/auth';
import { Link, useNavigate } from 'react-router-dom';
import { render } from '@testing-library/react';

export default function Home() {
    const [listaProdutos, setListaProdutos] = useState([]);
    const [listaConsumidores, setlistaConsumidores] = useState([]);
    const [reservando, setReservando] = useState(false);
    const [idConsumidor, setIdConsumidor] = useState('');

    let history = useNavigate();

    function ListarProdutos() {
        axios('https://6220fb53afd560ea69a3da5b.mockapi.io/Ofertas')
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
            axios('')
                .then(resposta => {
                    if (resposta.status === 200) {
                        resposta.data.map((consumidor) => {
                            if (consumidor.idUsuarioNavigation.idUsuario === localStorage.getItem('usuario-login').idUsuario) {
                                setIdConsumidor(consumidor.idConsumidor);
                            }
                        })
                        // setlistaConsumidores(resposta.data);
                        // var consumidorLogado = listaConsumidores.filter(item.idUsuarioNavigation.idUsuario === localStorage.getItem('usuario-login').idUsuario);
                        // setIdConsumidor(consumidorLogado.idConsumidor);
                    }
                })
            axios.post('requisicao', {
                idConsumidor : localStorage.getItem('usuario-login').Consumidor.idConsumidor,
                idProduto : produto.idProduto
            })
                .then(resposta => {
                    if (resposta.status === 204) {
                        console.log('produto reservado');
                        setReservando(false);
                        ListarProdutos();
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
