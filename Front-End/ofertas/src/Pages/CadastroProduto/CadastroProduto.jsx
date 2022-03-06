import { Component, useEffect, useState } from "react";
import axios from 'axios';
import { parseJwt, usuarioAutenticado } from "../../services/auth";
import { Link } from 'react-router-dom';
import Cabecalho from "../../Components/header";
import Rodape from "../../Components/footer";

export default function Produto(){
    //Cadastrar

    const [nomeProduto, setNomeProduto] = useState('');
    const [listaCategoria, setListaCategoria] = useState([]);
    const [idCategoria, setIdCategoria] = useState('');
    const[dataValidade, setDataValidade] = useState('');
    const[preco, setPreco] = useState('');
    const [imagemProduto, setImagemProduto] = useState('');
    
    function listarCategorias(){
        axios('http://localhost:5000/api/Categorias',{
            headers:{
                'Authorization': 'Bearer' + localStorage.getItem('usuario-login')
            }
        })
        .then(resposta=>{
            if (resposta.status === 200) {
                setListaCategoria(resposta.data)
            }
        })
        .catch(erro=>console.log(erro))
    }
    useEffect(listarCategorias, [])

    function cadastrarProdutos(evento){
        evento.preventDefault()

        axios.post('http://localhost:5000/api/Produtos', {
            nomeProduto: nomeProduto,
            idCategoria: idCategoria,
            dataValidade: dataValidade,
            preco: preco,
            imagemProduto: imagemProduto
        },{
            headers:{
                'Authorization': 'Bearer' + localStorage.getItem('usuario-login')
            }
        })
        .then(resposta=>{
            if (resposta.status === 201) {
                console.log('Produto Cadastrado');
                setNomeProduto('');
                setIdCategoria('');
                setDataValidade('');
                setPreco('');
                setImagemProduto('');
            }
        })
        .catch(erro=>console.log(erro))
    }
    return(
        <>
        <Cabecalho/>
        <h2>Cadastrar Produto</h2>
        <form onSubmit={cadastrarProdutos}>
            <input type="text" 
                    name="nomeProduto" 
                    id="nomeProduto"  
                    placeholder="Nome do Produto" 
                    value={nomeProduto}
                    onChange={(e)=>setNomeProduto(e.target.value)}
                    />

            <select name="categoria" 
                    id="categoria"
                    value={idCategoria}
                    onChange={(campo)=>setIdCategoria(campo.target.value)}
                    >
                        <option value ="0">Selecione a Categoria</option>
                        {listaCategoria.map((categoria)=>{
                            return(
                                <option key={categoria.idCategoria} value={categoria.idCategoria}>
                                    {categoria.nomeCategoria}
                                </option>
                            )
                        })}
                </select>

                <input type="datetime-local" 
                       name="dataValidade"
                       id="dataValidade"
                       value={dataValidade}
                       placeholder="Data de Validade"
                       onChange={(campo)=>setDataValidade(campo.target.value)} 
                />

                <input type="number" 
                       name="preco"
                       id="preco"
                       value={preco}
                       placeholder="Adicione o Preço"
                       onChange={(campo)=>setPreco(campo.target.value)} 
                />
                <input type="file" 
                       name="imagem"
                       value={imagemProduto}
                       accept="image/png, image/jpeg"
                       onChange={(campo)=>setImagemProduto(campo.target.value)}        
                       />
                       <button
                       type="submit"
                       name="botao"
                       id="botao"
                       onClick={(e)=>cadastrarProdutos(e)}
                       >
                           Cadastrar Produto
                       </button>
            </form>
            <Rodape/>
        </>
    )
}