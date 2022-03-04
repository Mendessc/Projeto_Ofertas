import { Component } from 'react';
import { useState, useEffect } from 'react';
import axios, { Axios } from 'axios';
import { parseJwt, usuarioAutenticado } from '../../services/auth';
import { NavLink, Link, BrowserRouter, useHistory } from 'react-router-dom';
import { render } from '@testing-library/react';

export default function Home() {
    const [listaProdutos, setListaProdutos] = useState([]);
    const [reservando, setReservando] = useState(false);
    let navigate = useHistory();
    function listarProdutos() {
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

    function reservarProduto(Produto) {
        if (usuarioAutenticado() && parseJwt().role == 'role') {
            setReservando(true);
            axios.post('requisicao')
                .then(resposta => {
                    if (resposta.status === 204) {
                        console.log('produto reservado');
                        setReservando(false);
                        listarProdutos();
                    }
                })
        } else {
            console.log('nao e consumidor, sem autorizacao para reservar');
            navigate('/Login');
        }
    }

        useEffect(listarProdutos, []);

        return (
            <div>
                {listaProdutos.map((produto) => {
                    return (
                        <div key={produto.idProduto}>
                            <h1>Botao reservar</h1>
                            {reservando ? null : <button onClick={() => reservarProduto(produto)}></button>}
                        </div>
                    )
                })}
            </div>
        );
    }