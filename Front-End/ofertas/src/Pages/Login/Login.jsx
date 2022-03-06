import { Component } from "react";
import axios from 'axios';
import { parseJwt, usuarioAutenticado } from "../../services/auth";
import { Link } from 'react-router-dom';
import Cabecalho from "../../Components/header";
import Rodape from "../../Components/footer";


export default class Login extends Component {
    constructor(props) {
        super(props);
        this.state = {
            email: '',
            senha: '',
            erroMensagem: '',
            isLoading: false,
        };
    }

    efetualogin = (log) => {
        log.preventDefault();

        this.setState({ erroMensagem: '', isLoading: true });

        axios.post('http://localhost:5000/api/Login', {
            email: this.state.email,
            senha: this.state.senha,
        }).then((resposta) => {
            if (resposta.status === 200) {
                localStorage.setItem('usuario-login', resposta.data.token);
                this.setState({ isLoading: false });
                console.log(usuarioAutenticado());
                console.log(parseJwt());
                if (parseJwt().role === '2' )  {
                    
                    this.context.history.push('/Home');
                }
            }
        })
            .catch(() => {
                this.setState({
                    erroMensagem: 'Email e/ou senha incorretas!',
                    isLoading: false
                });
            });
    }
    atualizaStateCampo = (campo) => {
        console.log(campo);

        this.setState({ [campo.target.name]: campo.target.value })
    };

    render() {
        return (
            <>
                <Cabecalho />
                <main>
                    <form onSubmit={this.efetualogin} className="form-login">
                        <span className="texto-email">Digite seu Email</span>
                        <input className="input-login" value={this.state.email} onChange={this.atualizaStateCampo} name="email" type="email" id="login_email" />
                        <span className="texto-senha">Digite sua Senha</span>
                        <input className="input-login" value={this.state.senha} onChange={this.atualizaStateCampo} name="senha" type="password" id="login_senha" />
                        <div className="botao-login">
                            <button type='submit' className="btn-login" id="btn_login">
                                Entrar
                            </button>
                        </div>
                    </form>
                </main>
                <Rodape />
            </>
        )
    }
}