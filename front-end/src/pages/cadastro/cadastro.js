import { React, Component } from 'react';
//import { Link } from 'react-router-dom';

import '../../assets/css/cadastro.css';

import Header from '../../components/header/header';
import Footer from '../../components/footer/footer';

export default class Cadastro extends Component{
    constructor(props){
        super(props);
        this.state = {
            listaConsultas : [],
            idMedico : 0,
            idPaciente : 0,
            idSituacao : 1,
            descricao : '',
            data : new Date(),
            listaMedicos : [],
            listaPacientes : [],
            isLoading : false
        }
    }

    //Fazer a requisição e trazer a lista de consultas
    buscarConsultas = () =>
    {
        //Faz a chamada para a API
        fetch('http://localhost:5000/api/Consulta')

        .then(resposta => {
            //Caso a requisição retorne um status code 200
            if (resposta.status === 200) {
                //Atualiza o state listaConsultas com os dados obtidos
                this.setState({ listaConsultas : resposta.data })
                console.log(this.state.listaConsultas)
            }
        })

        //Caso acorra algum erro, mostra ele no console do navegador
        .catch((erro) => console.log(erro))
    }
    
    //Fazer a requisição e trazer a lista de médicos
    buscarMedicos = () => 
    {
        fetch('http://localhost:5000/api/Medico')

        .then(resposta => {
            //Caso a requisição retorne um status code 200
            if (resposta.status === 200) {
                //Atualiza o state listaMedicos com os dados obtidos
                this.setState({ listaMedicos : resposta.data })
                console.log(this.state.listaMedicos)
            }
        })

        //Caso acorra algum erro, mostra ele no console do navegador
        .catch((erro) => console.log(erro))
    }

    //Fazer a requisição e trazer a lista de pacientes
    buscarPacientes = () =>
    {
        fetch('http://localhost:5000/api/Paciente')

        .then(resposta => {
            //Caso a requisição retorne um status code 200
            if (resposta.status === 200) {
                //Atualiza o state listaPacientes com os dados obtidos
                this.setState({ listaPacientes : resposta.data })
                console.log(this.state.listaPacientes)
            }
        })

        //Caso acorra algum erro, mostra ele no console do navegador
        .catch((erro) => console.log(erro))
    }

    buscarSituacao = () =>
    {
        fetch('http://localhost:5000/api/Situacao')

        .then(resposta => {
            //Caso a requisição retorne um status code 200
            if (resposta.status === 200) {
                //Atualiza o state listaSituacao com os dados obtidos
                this.setState({ listaSituacao : resposta.data })
                console.log(this.state.listaSituacao)
            }
        })

        //Caso acorra algum erro, mostra ele no console do navegador
        .catch((erro) => console.log(erro))
    }

    //Chama a função buscarConsultas() assim que o component é renderizado
    componentDidMount()
    {
        this.buscarConsultas();
        this.buscarMedicos();
        this.buscarPacientes();
    }

    //Função responsável por cadastrar uma nova consulta
    cadastrarConsulta = (x) =>
    {
        //Ignora a ação padrão do navegador, que é atualizar(recarregar) a página inteira
        x.preventDefault();

        //Define que a requisição está em andamento
        this.setState({ isLoading : true })

        let consulta = {
            idPaciente : this.state.idPaciente,
            idMedico : this.state.idMedico,
            dataConsulta : new Date( this.state.data ),
            idSituacao : this.state.idSituacao,
            descricao : this.state.descricao
        }

        fetch('http://localhost:5000/api/Consulta', {

            method : 'POST',

            body : JSON.stringify({ consulta }),
        })

        .then(resposta => {
            //Caso a requisição retorne um status code 200
            if (resposta.status === 201) {
                //Exibe no console do navegado uma mensagem
                console.log('Evento cadastrado')
                //Define que a requisição terminou
                this.setState({ isLoading : false })
                //Atualiza o state listaSituacao com os dados obtidos
                this.setState({ listaSituacao : resposta.data })
                console.log(this.state.listaSituacao)
            }
        })

        .catch(erro => {
            //Mostra o erro no console do navegador
            console.log(erro)
            //Define que a requisição terminou
            this.setState({ isLoading : false })
        })

        //Atualiza a lista de consultas sem que o usuário precise fazer alguma outra ação
        .then(this.buscarConsultas()); 
    }

    //Função genérica que atualiza o state de acordo com o input, pode ser ultilizada em vários inputs diferentes
    atualizaStateCampo = (x) =>
    {
        this.setState({ [x.target.name] : x.target.value })
    }

    render()
    {
        return(
            <div className='body'>
                <Header />
                <main className='main-cadastro'>
                    <div className="alinhando-centro">
                        <div className="informacoes-cadastro">
                            <h2>Nova Consulta</h2>
                            <div className="card-cadastro">
                                <form className="info-cards" onSubmit={this.cadastrarConsulta}>
                                    <div className="caixa-texto">
                                        <p>CRM do médico</p>
                                        <input
                                            type="text"
                                            value={this.state.idMedico}
                                            onChange={this.atualizaStateCampo}
                                        />
                                    </div>
                                    <div className="caixa-texto">
                                        <p>CPF do paciente</p>
                                        <select name='idPaciente' value={this.state.idPaciente} onChange={this.atualizaStateCampo}>
                                            <option value='0'>Selecione o CPF do paciente</option>

                                            {/* Usa o map() para preencher a lista de opções, ou seja, percorre a lista de pacientes e retorna uma option para cada paciente definindo o valor como seu prórpio id */}

                                            {
                                                this.state.listaPacientes.map( paciente => {
                                                    return(
                                                        <option key={paciente.idPaciente} value={paciente.idPaciente}>{paciente.cpf}</option>
                                                    )
                                                })
                                            }

                                        </select>
                                    </div>
                                    <div className="caixa-texto">
                                        <p>Dia e hora</p>
                                        <input
                                            name='data'
                                            type="date"
                                            value={this.state.data}
                                            onChange={this.atualizaStateCampo}
                                        />
                                    </div>
                                    <button type="submit">Cadastrar</button>
                                </form>
                            </div>
                        </div>
                    </div>
                </main>
                <Footer />
            </div>
        );
    }
}