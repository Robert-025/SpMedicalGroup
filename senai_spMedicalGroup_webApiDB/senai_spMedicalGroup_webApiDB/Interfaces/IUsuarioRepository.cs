using senai_spMedicalGroup_webApiDB.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spMedicalGroup_webApiDB.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório pelo UsuarioRepository
    /// </summary>
    interface IUsuarioRepository
    {
        /// <summary>
        /// Valida o usuario
        /// </summary>
        /// <param name="email">e-mail do usuario</param>
        /// <param name="senha">senha do usuario</param>
        /// <returns>O usuario encontrado</returns>
        usuario Login(string email, string senha);

        /// <summary>
        /// Lista todos os usuario
        /// </summary>
        /// <returns>Uma lista de usuarios</returns>
        List<usuario> Listar();

        /// <summary>
        /// Lista os usuarios e os tipos quem ele pertence
        /// </summary>
        /// <returns>Uma lista de usuarios com os tipos de usuarios</returns>
        List<usuario> ListarTipo();

        /// <summary>
        /// Busca um usuario pelo seu id
        /// </summary>
        /// <param name="id">Id do usuario que será buscado</param>
        /// <returns>O usuario buscado</returns>
        usuario BuscarPorId(int id);

        /// <summary>
        /// Atualiza um usuario passando o id na url
        /// </summary>
        /// <param name="id">Id do usuario que será atualizado</param>
        /// <param name="usuarioAtualizado">Objeto com as novas informações</param>
        void Atualizar(int id, usuario usuarioAtualizado);

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="novoUsuario">Objeto com as informações que serão cadastradas</param>
        void Cadastrar(usuario novoUsuario);

        /// <summary>
        /// Deleta um usuario existente
        /// </summary>
        /// <param name="id">Id do usuario que será deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Lista os usuarios e os medicos que estão atrelados a eles
        /// </summary>
        /// <returns></returns>
        List<usuario> ListarMedicos();

        /// <summary>
        /// Lista os usuarios e os pacientes que estão atrelados a eles
        /// </summary>
        /// <returns></returns>
        List<usuario> ListarPacientes();
    }
}
