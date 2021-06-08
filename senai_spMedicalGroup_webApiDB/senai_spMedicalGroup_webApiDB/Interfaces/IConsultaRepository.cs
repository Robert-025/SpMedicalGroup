using senai_spMedicalGroup_webApiDB.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spMedicalGroup_webApiDB.Interfaces
{
    /// <summary>
    /// Interface responsável pelo ConsultaRepository
    /// </summary>
    interface IConsultaRepository
    {
        /// <summary>
        /// Lista todas as consultas que um determinado usuario participa
        /// </summary>
        /// <param name="id">Id do usuario que participa das consultas listados</param>
        /// <returns>Uma lista de consultas com os dados da consulta</returns>
        List<consulta> ListarMinhas(int id);

        /// <summary>
        /// Cria uma nova consulta
        /// </summary>
        /// <param name="consulta">Objeto com as informãções da consulta</param>
        void Inscrever(consulta consulta);

        /// <summary>
        /// Altera o status de uma consulta
        /// </summary>
        /// <param name="id">Id da consulta que terá sua situação alterada</param>
        /// <param name="status">Parâmetro que atualiza a situação da consulta para -> 1 - Agendada, - Realizada e 3 - Cancelada</param>
        void AprovarRecusar(int id, string status);

        /// <summary>
        /// Lista todas as consultas cadastradas
        /// </summary>
        /// <returns>Uma lista com as consultas</returns>
        List<consulta> ListarConsultas();

        /// <summary>
        /// Busca uma consulta pelo seu id
        /// </summary>
        /// <param name="id">Id da consulta que será buscada</param>
        /// <returns>A consulta buscada</returns>
        consulta BuscarPorId(int id);

        /// <summary>
        /// Deleta uma consulta passadno seu id na url da requisição
        /// </summary>
        /// <param name="id">Id da consulta que será deletada</param>
        void Deletar(int id);

        /// <summary>
        /// Busca um médico pelo seu nome para inserir ele no cadastro da consulta
        /// </summary>
        /// <param name="nomeMedico">Nome do médico que será atrelado a consulta</param>
        /// <returns>O médico buscado</returns>
        medico BuscarPorNome(string nomeMedico);

        /// <summary>
        /// Cadastra uma nova consulta
        /// </summary>
        /// <param name="novaConsulta">Objeto com as informações que serão cadastradas</param>
        void Cadastrar(consulta novaConsulta);

        /// <summary>
        /// Busca um paciente pelo seu rg
        /// </summary>
        /// <param name="rg">RG do paciente que será buscado</param>
        /// <returns>O paciente buscado</returns>
        paciente BuscarPorRg(string rg);

        /// <summary>
        /// Atualiza uma consulta passando seu id na url
        /// </summary>
        /// <param name="id">ID da consulta que será atualizada</param>
        /// <param name="consultaAtualizada">Objeto com asnovas informações</param>
        void Atualizar(int id, consulta consultaAtualizada);
    }
}
