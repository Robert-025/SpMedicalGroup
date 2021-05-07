using senai_spMedicalGroup_webApiDB.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spMedicalGroup_webApiDB.Interfaces
{
    /// <summary>
    /// Interface responsável pelo TiposUsuarioRepository
    /// </summary>
    interface ITiposUsuarioRepository
    {
        /// <summary>
        /// Listar os todos os tipos de usuario
        /// </summary>
        /// <returns>Uma lista com os tipos de usuario</returns>
        List<tiposUsuario> Listar();

        /// <summary>
        /// Busca um tipo de usuario pelo seu id
        /// </summary>
        /// <param name="id">Id do tipo de usuario que será buscado</param>
        /// <returns>O tipo de usuario buscado</returns>
        tiposUsuario BuscarPorId(int id);

        /// <summary>
        /// Lista todos os tipos de usuario com os usuarios que pertencem a eles
        /// </summary>
        /// <returns>A lista de tipos de usuario com os usuarios</returns>
        List<tiposUsuario> ListarUsuarios();

        /// <summary>
        /// Cadastra um novo tipo de usuario
        /// </summary>
        /// <param name="novoTipo">Objeto com as informações que serão cadastradas</param>
        void Cadastrar(tiposUsuario novoTipo);

        /// <summary>
        /// Deleta um usuario
        /// </summary>
        /// <param name="id">Id do usuario que será deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Atualiza um tipo de usuario passando o id na url da requisição
        /// </summary>
        /// <param name="id">Id do tipo de usuario que será atualizado</param>
        /// <param name="tUsuarioAtualizado">Objeto com as informações que serão atualizadas</param>
        void Atualizar(int id, tiposUsuario tUsuarioAtualizado);
    }
}
