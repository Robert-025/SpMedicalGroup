using senai_spMedicalGroup_webApiDB.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spMedicalGroup_webApiDB.Interfaces
{
    /// <summary>
    /// Interface responsável pelo MedicoRepository
    /// </summary>
    interface IMedicoRepository
    {
        /// <summary>
        /// Atualiza um médico passando seu id na url da requisição
        /// </summary>
        /// <param name="id">Id do médico que será atualizado</param>
        /// <param name="medicoAtualizado">Objeto com as informações a serem gravadas</param>
        void Atualizar(int id, medico medicoAtualizado);

        /// <summary>
        /// Busca um médico pelo seu id
        /// </summary>
        /// <param name="id">Id do médico que será buscado</param>
        /// <returns>O médico buscado</returns>
        medico BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo médico
        /// </summary>
        /// <param name="novoMedico">Objeto com </param>
        void Cadastrar(medico novoMedico);

        /// <summary>
        /// Deleta um médico pelo seu id
        /// </summary>
        /// <param name="id">Id do médico que sérá deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Lista os médicos com as clínicas a que ele pertence
        /// </summary>
        /// <returns>A lista de médicos com as clínicas</returns>
        List<medico> ListarClinica();

        /// <summary>
        /// Lista os médicos com as consultas atreladas a eles
        /// </summary>
        /// <returns>
        /// A lista de médicos com as consultas</returns>
        List<medico> ListarConsulta();

        /// <summary>
        /// Lista os médicos e as suas especialidades
        /// </summary>
        /// <returns>A lista de médicos com as suas especialidades</returns>
        List<medico> ListarEspecialidade();
        
        /// <summary>
        /// Lista todos os médicos com seus atributos de usuarios incluídos
        /// </summary>
        /// <returns>Uma lista de médicos com os atributos de usuario incluídos</returns>
        List<medico> ListarMedicos();
    }
}
