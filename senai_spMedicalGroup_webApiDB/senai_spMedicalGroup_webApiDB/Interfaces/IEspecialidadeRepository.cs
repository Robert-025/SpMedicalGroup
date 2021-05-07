using senai_spMedicalGroup_webApiDB.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spMedicalGroup_webApiDB.Interfaces
{
    /// <summary>
    /// Interface responsável pelo EspecialidadeRepository
    /// </summary>
    interface IEspecialidadeRepository
    {
        /// <summary>
        /// Lista todas as especialidades
        /// </summary>
        /// <returns>Uma lista de especialidade</returns>
        List<especialidade> Listar();

        /// <summary>
        /// Lista todas as especialidade e os médicos que à tem
        /// </summary>
        /// <returns>Uma lista de especialidade com os médicos</returns>
        List<especialidade> ListarMedicos();

        /// <summary>
        /// Busca uma especialidade pelo seu id
        /// </summary>
        /// <param name="id">Id da especialidade que será buscada</param>
        /// <returns>A especialidade buscada</returns>
        especialidade BuscarPorId(int id);

        /// <summary>
        /// Cadastra uma nova especialidade
        /// </summary>
        /// <param name="novaEspecialidade">Objeto com as informações que serão cadastradas</param>
        void Cadastrar(especialidade novaEspecialidade);

        /// <summary>
        /// Deleta uma especialidade existente
        /// </summary>
        /// <param name="id">Id da especialidade que será deletada</param>
        void Deletar(int id);

        /// <summary>
        /// Atualiza uma especialidade passando seu id na url da requisição
        /// </summary>
        /// <param name="id">Id da especialidade que será atualizada</param>
        /// <param name="especialidadeAtualizada">Objeto com as informações que serão atualizadas</param>
        void Atualizar(int id, especialidade especialidadeAtualizada);
    }
}
