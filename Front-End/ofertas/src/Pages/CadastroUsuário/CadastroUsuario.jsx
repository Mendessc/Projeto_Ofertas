import { Component, useEffect, useState } from "react";
import axios from 'axios';
import { parseJwt, usuarioAutenticado } from "../../services/auth";
import { Link } from 'react-router-dom';
import Cabecalho from "../../Components/header";
import Rodape from "../../Components/footer";
import '../../assets/css/cadastroU.css';

export default function Usuario() {

    const [idTipoUsuario, setIdTipoUsuario] = useState('');
    const [listaTipoUsuario, setListaTipoUsuario] = useState([]);
    const [email, setEmail] = useState('');
    const [senha, setSenha] = useState('');

    function listarTipoUsuario() {
        axios('http://localhost:5000/api/TiposUsuarios', {
            headers: {
                'Authorization': 'Bearer' + localStorage.getItem('usuario-login')
            }
        })
            .then(resposta => {
                if (resposta.status === 200) {
                    setListaTipoUsuario(resposta.data)
                    console.log(listaTipoUsuario)
                }
            })
            .catch(erro => console.log(erro))
    }
    useEffect(listarTipoUsuario, [])

    function Cadastrar(evento) {
        evento.preventDefault()

        console.log(email);
        console.log(senha);
        console.log(idTipoUsuario);

        axios.post('http://localhost:5000/api/Usuario', {
            idTipoUsuario: idTipoUsuario,
            email: email,
            senha: senha
        })
            .then(resposta => {
                if (resposta.status === 201) {
                    console.log('Usuario Cadastrado')
                    setIdTipoUsuario('');
                    setEmail('');
                    setSenha('');
                }
            })
            .catch(erro => console.log(erro))
    }
    return (
        <>
            <Cabecalho />
            <section className="div_cadastro container">
                <div className="box_cad">
                    <div className="header_cad">
                        <h2>Cadastrar Usuario</h2>
                    </div>
                    <hr />
                    <form onSubmit={Cadastrar}>
                        <div className="box_input">
                            <select className="select_id"
                                name="tipo"
                                id="tipo"
                                value={idTipoUsuario}
                                onChange={(campo) => setIdTipoUsuario(campo.target.value)}
                            >
                                <option value="0">Selecione o tipo da Conta</option>
                                <option value="2">Consumidor</option>
                                <option value="3">Fornecedor</option>
                            </select>
                        </div>
                        <div className="box_input">
                            <input className="input_cad"
                                type="email"
                                name="email"
                                id="email"
                                value={email}
                                placeholder="Digite seu Email"
                                onChange={(campo) => setEmail(campo.target.value)}
                            />
                        </div>

                        <div className="box_input">
                            <input className="input_cad"
                                type="password"
                                name="senha"
                                id="senha"
                                value={senha}
                                placeholder="Digite sua Senha"
                                onChange={(campo) => setSenha(campo.target.value)}
                            />
                        </div>

                        <div className="box_botao">
                            <button className="botao_cad"
                                type="submit"
                                name="botao_Cad"
                                id="botao_Cad"
                                onClick={(e) => Cadastrar(e)}
                            >
                                Cadastrar
                            </button>
                        </div>
                    </form>
                </div>
            </section>
            <footer>
                <Rodape />
            </footer>
        </>
    )
}