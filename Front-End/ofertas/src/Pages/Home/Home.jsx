import { Component } from 'react';
import { useState, useEffect } from 'react';
import axios, { Axios } from 'axios';
import { parseJwt, usuarioAutenticado } from '../../services/auth';
import { Link, useNavigate } from 'react-router-dom';
import { render } from '@testing-library/react';

//CSS:
import '../../assets/css/home.css';

//Componentes:
import Cabecalho from "../../Components/header";
import Rodape from "../../Components/footer";

//img:
import coca from "../../assets/img/Home/coca.png";
import liza from "../../assets/img/Home/liza.png";
import qualy from "../../assets/img/Home/qualy.png";
import friboi from "../../assets/img/Home/friboi.png";
import yoki from "../../assets/img/Home/yoki.png";
import aurora from "../../assets/img/Home/aurora.png";

export default function Home() {
    const [listaProdutos, setListaProdutos] = useState([]);
    const [listaConsumidores, setListaConsumidores] = useState([]);
    const [reservando, setReservando] = useState(false);
    const [idConsumidor, setidConsumidor] = useState(null);

    let history = useNavigate();

     function ListarProdutos() {

        axios('http://localhost:5000/api/Produto/SemReservas')
            .then(resposta => {
                if (resposta.status === 200) {
                    console.log(resposta.data);
                    setListaProdutos(resposta.data);
                    console.log(listaProdutos);
                    
                    if (listaProdutos = null) {
                        alert("Desculpe, todas as ofertas já estão reservadas :(");
                    }
                }
            })
            .catch(erro => console.log(erro))
    }

    function MsgLista() {
        
    }

    function ReservarProduto(produto) {
        if (usuarioAutenticado() && parseJwt().role === '2') {
            setReservando(true);
            axios('http://localhost:5000/api/Consumidor')
                .then(resposta => {
                    if (resposta.status === 200) {
                        console.log(resposta.data);
                        resposta.data.map((consumidor) => {
                            if (consumidor.idUsuario == parseJwt().jti) {
                                setidConsumidor(consumidor.idConsumidor);
                                console.log('idConsumidor encontrado');
                                axios.post('http://localhost:5000/api/Reserva', {
                                    idConsumidor: consumidor.idConsumidor,
                                    idProduto: produto.idProduto
                                }, {
                                    headers: {
                                        'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
                                    }
                                })
                                    .then(resposta => {
                                        if (resposta.status == 201) {
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

    //setTimeout(ListarProdutos, 1000);
     useEffect(ListarProdutos, []);

    return (

        <div>
            <Cabecalho />
            <h1 className="container ofertas_Home">Ofertas do dia</h1>
            <div className="container areaProdutos_Home" >
                {listaProdutos.map((produto) => {
                    return (
                        <div className="cadaProdutoListado_Home" key={produto.idProduto}>
                            <div className="imgProduto_Home">
                                <img src={"http://localhost:5000/img/" + produto.imagemProduto} alt="" />
                            </div>
                            <div className="dadosProdutos_Home">
                                <div className="dadosProduto_Home">
                                    <p>{produto.nomeProduto}</p>
                                    <p>Fornecedor: {produto.idFornecedorNavigation.nome}</p>
                                    <span className="nomeCategoria">{produto.idCategoriaNavigation.nomeCategoria}</span>
                                </div>
                                <div className="areaPrecoLevar_Home">
                                    <span className="preco_home" >R$ {produto.preco}</span>
                                    {reservando ? null : <button className='botaoLevar_Home' onClick={() => ReservarProduto(produto)}>Levar</button>}
                                </div>
                            </div>
                            <div className="areaValidade">
                                <span>Vence em {Intl.DateTimeFormat("pt-br", {
                                    year: 'numeric', month: 'numeric', day: 'numeric',
                                }).format(new Date(produto.dataValidade))
                                }</span>
                            </div>
                        </div>
                    )
                })}
            </div>
            <div className="container areaMarcas_Home">
                <h1>Aqui tem</h1>
                <div className="imgMarcas_Home">
                    <img src={coca} alt="CocaCola" />
                    <div className="imgDoMeio_Home">
                        <img src={liza} alt="Liza" />
                        <img src={qualy} alt="Qualy" />
                    </div>
                    <div className="imgDoMeio_Home2">
                        <img src={friboi} alt="Friboi" />
                        <img src={yoki} alt="Yoki" />
                    </div>
                    <img src={aurora} alt="aurora" />
                </div>
            </div>
            <Rodape />
        </div>

    );
}