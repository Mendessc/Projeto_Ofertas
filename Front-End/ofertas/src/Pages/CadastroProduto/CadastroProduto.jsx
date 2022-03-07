import { Component, useEffect, useState } from "react";
import axios from 'axios';
import { parseJwt, usuarioAutenticado } from "../../services/auth";
import { Link } from 'react-router-dom';
import Cabecalho from "../../Components/header";
import Rodape from "../../Components/footer";

export default function Produto() {
    //Cadastrar

    const [nomeProduto, setNomeProduto] = useState('');
    const [descricaoProduto, setDescProd] = useState('');
    const [listaCategoria, setListaCategoria] = useState([]);
    const [listaFornecedor, setListaFornecedor] = useState({});
    const [idCategoria, setIdCategoria] = useState('');
    const [dataValidade, setDataValidade] = useState('');
    const [preco, setPreco] = useState('');
    const [imagemProduto, setImagemProduto] = useState('');

    function listarCategorias() {
        axios('http://localhost:5000/api/Categorias', {
            headers: {
                'Authorization': 'Bearer' + localStorage.getItem('usuario-login')
            }
        })
            .then(resposta => {
                if (resposta.status === 200) {
                    setListaCategoria(resposta.data)
                }
            })
            .catch(erro => console.log(erro))
    }

    function listarFornecedor() {
        axios('http://localhost:5000/api/Fornecedor/' + parseJwt().jti, {
            headers: {
                Authorization: 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
            .then(resposta => {
                if (resposta.status === 200) {
                    setListaFornecedor(resposta.data)
                }
            })
            .catch(erro => console.log(erro))
    }

    useEffect(listarCategorias, [])
    useEffect(listarFornecedor, [])

    function cadastrarProdutos(evento) {
        evento.preventDefault()

        var forms = new FormData();

        const element = document.getElementById('arquivo')
        const file = element.files[0]
        console.log(file)
        forms.append('arquivo', file, file.name)
        // formData.append('arquivo', file, file.name)


        forms.append('idFornecedor', listaFornecedor.idFornecedor);
        forms.append('nomeProduto', nomeProduto)
        //  formData.append('imagem', imagemProduto);
        forms.append('descricao', descricaoProduto);
        forms.append('idCategoria', idCategoria);
        forms.append('dataValidade', dataValidade);
        forms.append('preco', preco);
        console.log(listaFornecedor.idFornecedor)
        console.log(descricaoProduto)
        console.log(idCategoria)
        console.log(dataValidade)
        console.log(preco)
        axios({
            method: 'post',
            url: 'http://localhost:5000/api/Produto',
            data: forms,
            headers: {
                "Content-Type": "multipart/form-data",
                "Authorization": `Bearer ${localStorage.getItem('usuario-login')}`
            }
        })
            .then(resposta => {
                if (resposta.status === 201) {
                    console.log('Produto Cadastrado');
                    setNomeProduto('');
                    setIdCategoria('');
                    setDataValidade('');
                    setPreco('');
                    setImagemProduto('');
                }
            })
            .catch(erro => console.log(erro))
    }
    return (
        <>
            <Cabecalho />
            <main className="ContainerMain">
                <form className="form-login" onSubmit={cadastrarProdutos}>
                    <h2 className="Titulo-login">Cadastrar Produto</h2>
                    <input
                        className="input-login"
                        type="text"
                        name="nomeProduto"
                        id="nomeProduto"
                        placeholder="Nome do Produto"
                        value={nomeProduto}
                        onChange={(e) => setNomeProduto(e.target.value)}
                    />

                    <input
                        className="input-login"
                        type="text"
                        name="descProduto"
                        id="descProduto"
                        placeholder="Descrição do Produto"
                        value={descricaoProduto}
                        onChange={(e) => setDescProd(e.target.value)}
                    />

                    <select
                        className="input-login select-selected"
                        name="categoria"
                        id="categoria"
                        value={idCategoria}
                        onChange={(campo) => setIdCategoria(campo.target.value)}
                    >
                        <option className="select-items" value="0">Selecione a Categoria</option>
                        {listaCategoria.map((categoria) => {
                            return (
                                <option className="select-items" key={categoria.idCategoria} value={categoria.idCategoria}>
                                    {categoria.nomeCategoria}
                                </option>
                            )
                        })}
                    </select>

                    <input
                        className="input-login"
                        type="date"
                        name="dataValidade"
                        id="dataValidade"
                        value={dataValidade}
                        placeholder="Data de Validade"
                        onChange={(campo) => setDataValidade(campo.target.value)}
                    />

                    <input
                        className="input-login"
                        type="number"
                        name="preco"
                        id="preco"
                        value={preco}
                        placeholder="Adicione o Preço"
                        onChange={(campo) => setPreco(campo.target.value)}
                    />
                    
                    <span className="label-cadastroProd">Selecionar Foto</span>
                        <input
                            className="input-login inputImage-cadastroProd"
                            type="file"
                            name="arquivo"
                            id="arquivo"
                            value={imagemProduto}
                            accept="image/png, image/jpeg, image/jpg"
                            onChange={(campo) => setImagemProduto(campo.target.value)}
                        />
                    
                    <button
                        className="btn-CadatrarProd"
                        type="submit"
                        name="botao"
                        id="botao"
                        onClick={(e) => cadastrarProdutos(e)}
                    >
                        Cadastrar Produto
                    </button>
                </form>
            </main>
            <Rodape />
        </>
    )
}