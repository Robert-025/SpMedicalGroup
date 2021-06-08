using senai_spMedicalGroup_webApiDB.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spMedicalGroup_webApiDB.Interfaces
{
    /// <summary>
    /// Interface responsável pelo PacienteRepository
    /// </summary>
    interface IPacienteRepository
    {
        /// <summary>
        /// Lista os pacientes com suas consultas
        /// </summary>
        /// <returns>Uma lista de consultas</returns>
        List<paciente> ListarConsultas();

        /// <summary>
        /// Lista todos os pacientes com suas características de usuario
        /// </summary>
        /// <returns>Uma lista de pacientes</returns>
        List<paciente> ListarPaciente();

        /// <summary>
        /// Busca um paciente pelo seu id
        /// </summary>
        /// <param name="id">Id do paciente que será buscado</param>
        /// <returns>O paciente buscado</returns>
        paciente BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo paciente
        /// </summary>
        /// <param name="novoPaciente">Objeto com as informações que serão cadastradas</param>
        void Cadastrar(paciente novoPaciente);

        /// <summary>
        /// Deleta um paciente existente
        /// </summary>
        /// <param name="id">Id do paciente que será deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Atualiza um paciente passando seu id na url da requisição
        /// </summary>
        /// <param name="id">Id do paciente que será atualizado</param>
        /// <param name="pacienteAtualizado">Objeto com as informações que serão atualizadas</param>
        void Atualizar(int id, paciente pacienteAtualizado);
    }
}
