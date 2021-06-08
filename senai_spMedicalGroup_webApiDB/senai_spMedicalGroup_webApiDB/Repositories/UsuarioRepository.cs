using Microsoft.EntityFrameworkCore;
using senai_spMedicalGroup_webApiDB.Context;
using senai_spMedicalGroup_webApiDB.Domains;
using senai_spMedicalGroup_webApiDB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spMedicalGroup_webApiDB.Repositories
{
    /// <summary>
    /// Classe responsável pelo repositório dos usuarios
    /// </summary>
    public class UsuarioRepository : IUsuarioRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        SpMedicalGroupContext ctx = new SpMedicalGroupContext();

        /// <summary>
        /// Atualiza um usuario passando o id na url
        /// </summary>
        /// <param name="id">Id do usuario que será atualizado</param>
        /// <param name="usuarioAtualizado">Objeto com as novas informações</param>
        public void Atualizar(int id, usuario usuarioAtualizado)
        {
            //Busca o usuario que será atualizado pelo seu id
            usuario usuarioBuscado = BuscarPorId(id);

            // IF -> Verifica se o atributo do paciente foi informado

            // xx.xx = yy.xx -> Atribui o valor informado ao paciente que será atualizado

            if (usuarioAtualizado.idTipo != null)
            {
                usuarioBuscado.idTipo = usuarioAtualizado.idTipo;
            }

            if (usuarioAtualizado.nome != null)
            {
                usuarioBuscado.nome = usuarioAtualizado.nome;
            }

            if (usuarioAtualizado.email != null)
            {
                usuarioBuscado.email = usuarioAtualizado.email;
            }

            if (usuarioAtualizado.senha != null)
            {
                usuarioBuscado.senha = usuarioAtualizado.senha;
            }

            //Atualiza o usuarioBuscado da lista de usuarios
            ctx.usuarios.Update(usuarioBuscado);

            //Salva as alterações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um usuario pelo seu id
        /// </summary>
        /// <param name="id">Id do usuario que será buscado</param>
        /// <returns>O usuario buscado</returns>
        public usuario BuscarPorId(int id)
        {
            //Retorna a busca na lista usuarios o id informado
            return ctx.usuarios.Find(id);
        }

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="novoUsuario">Objeto com as informações que serão cadastradas</param>
        public void Cadastrar(usuario novoUsuario)
        {
            //Adiciona o novoUsuario na lista usuarios
            ctx.usuarios.Add(novoUsuario);

            //Salva as informações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um usuario existente
        /// </summary>
        /// <param name="id">Id do usuario que será deletado</param>
        public void Deletar(int id)
        {
            //Remove o usuario que está sendo buscado 
            ctx.usuarios.Remove(BuscarPorId(id));

            //Salva as alterações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os usuario
        /// </summary>
        /// <returns>Uma lista de usuarios</returns>
        public List<usuario> Listar()
        {
            //Retorna a lista de usuarios
            return ctx.usuarios.ToList();
        }


        /// <summary>
        /// Lista os usuarios e os medicos que estão atrelados a eles
        /// </summary>
        /// <returns></returns>
        public List<usuario> ListarMedicos()
        {
            //Retorna a lista de usuarios incluindo os médicos que estão atrelados a eles
            return ctx.usuarios.Include(u => u.medicos)
                               .Where(u => u.idTipo == 2)
                               .ToList();
        }

        /// <summary>
        /// Lista os usuarios e os pacientes que estão atrelados a eles
        /// </summary>
        /// <returns></returns>
        public List<usuario> ListarPacientes()
        {
            //Retorna a lista de usuarios incluindo os pacientes que estão atrelados a eles
            return ctx.usuarios.Include(u => u.pacientes)
                               .Where(u => u.idTipo == 3) 
                               .ToList();
        }

        /// <summary>
        /// Lista os usuarios e os tipos quem ele pertence
        /// </summary>
        /// <returns>Uma lista de usuarios com os tipos de usuarios</returns>
        public List<usuario> ListarTipo()
        {
            //Retorna a lista de usuarios com os tipos atrelados
            return ctx.usuarios.Include(u => u.idTipoNavigation).ToList();
        }

        /// <summary>
        /// Valida o usuario
        /// </summary>
        /// <param name="email">e-mail do usuario</param>
        /// <param name="senha">senha do usuario</param>
        /// <returns>O usuario encontrado</returns>
        public usuario Login(string email, string senha)
        {
            //Retorna o usuario encontrado através do email e da senha
            return ctx.usuarios.FirstOrDefault(u => u.email == email && u.senha == senha); 
        }
    }
}
