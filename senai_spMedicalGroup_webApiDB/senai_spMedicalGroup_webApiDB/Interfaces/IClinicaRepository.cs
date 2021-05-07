using senai_spMedicalGroup_webApiDB.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spMedicalGroup_webApiDB.Interfaces
{
    /// <summary>
    /// Interface responsável por ClinicaRepository
    /// </summary>
    interface IClinicaRepository
    {
        /// <summary>
        /// Lista todas as clínicas
        /// </summary>
        /// <returns>Uma lista de clínicas</returns>
        List<clinica> Listar();

        /// <summary>
        /// Lista todas as clínicas e os médicos que pertencem a ela
        /// </summary>
        /// <returns>Uma lista de clínicas com os médicos</returns>
        List<clinica> ListarMedicos();

        /// <summary>
        /// Busca uma clínica pelo seu id
        /// </summary>
        /// <param name="id">Id da clinica que vai ser buscada</param>
        /// <returns>A clinica buscada</returns>
        clinica BuscarPorId(int id);

        /// <summary>
        /// Cadastra uma nova clínica
        /// </summary>
        /// <param name="novaClinica">Objeto com as informações que serão cadastradas</param>
        void Cadastrar(clinica novaClinica);

        /// <summary>
        /// Atualiza uma clínica passando seu id na url da requisição
        /// </summary>
        /// <param name="id">Id da clínica que será atualizada</param>
        /// <param name="clinicaAtualizada">Objeto com as informações informadas</param>
        void Atualizar(int id, clinica clinicaAtualizada);

        /// <summary>
        /// Deleta uma clínica existente
        /// </summary>
        /// <param name="id">Id da clínica que será deletada</param>
        void Deletar(int id);
    }
}
