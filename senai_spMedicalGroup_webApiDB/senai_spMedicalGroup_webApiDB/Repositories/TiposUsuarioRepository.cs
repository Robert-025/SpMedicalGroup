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
    public class TiposUsuarioRepository : ITiposUsuarioRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        SpMedicalGroupContext ctx = new SpMedicalGroupContext();

        /// <summary>
        /// Atualiza um tipo de usuario passando o id na url da requisição
        /// </summary>
        /// <param name="id">Id do tipo de usuario que será atualizado</param>
        /// <param name="tUsuarioAtualizado">Objeto com as informações que serão atualizadas</param>
        public void Atualizar(int id, tiposUsuario tUsuarioAtualizado)
        {
            //Busca um tipo de usuario pelo seu id
            tiposUsuario tipoBuscado = BuscarPorId(id);

            //Verifica se o nome do tipoUsuario foi informado
            if (tipoBuscado.tituloTipo != null)
            {
                //Caso seja, atribui o novo valor ao campo
                tipoBuscado.tituloTipo = tUsuarioAtualizado.tituloTipo;
            }

            //Atualiza o tipoUsuario que foi buscado
            ctx.tiposUsuarios.Update(tipoBuscado);

            //Salva as alterações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um tipo de usuario pelo seu id
        /// </summary>
        /// <param name="id">Id do tipo de usuario que será buscado</param>
        /// <returns>O tipo de usuario buscado</returns>
        public tiposUsuario BuscarPorId(int id)
        {
            //Retorna o Tipo de usuario encontrado para o ID informado
            return ctx.tiposUsuarios.Find(id);
        }

        /// <summary>
        /// Cadastra um novo tipo de usuario
        /// </summary>
        /// <param name="novoTipo">Objeto com as informações que serão cadastradas</param>
        public void Cadastrar(tiposUsuario novoTipo)
        {
            //Adiciona o novoTipo
            ctx.tiposUsuarios.Add(novoTipo);

            //Salva as informações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um usuario
        /// </summary>
        /// <param name="id">Id do usuario que será deletado</param>
        public void Deletar(int id)
        {
            //Remove o tipo de usuario que está sendo buscado
            ctx.tiposUsuarios.Remove(BuscarPorId(id));

            //Salva as alterações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Listar os todos os tipos de usuario
        /// </summary>
        /// <returns>Uma lista com os tipos de usuario</returns>
        public List<tiposUsuario> ListarUsuarios()
        {
            //Retorna uma lista de tipos de habilidades com suas habilidades
            return ctx.tiposUsuarios.Include(t => t.usuarios).ToList();
        }

        /// <summary>
        /// Lista todos os tipos de usuario com os usuarios que pertencem a eles
        /// </summary>
        /// <returns>A lista de tipos de usuario com os usuarios</returns>
        public List<tiposUsuario> Listar()
        {
            //Retorna uma lista com todas as informações dos tiposUsuarios
            return ctx.tiposUsuarios.ToList();
        }
    }
}
