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
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        SpMedicalGroupContext ctx = new SpMedicalGroupContext();

        /// <summary>
        /// Atualiza uma especialidade passando seu id na url da requisição
        /// </summary>
        /// <param name="id">Id da especialidade que será atualizada</param>
        /// <param name="especialidadeAtualizada">Objeto com as informações que serão atualizadas</param>
        public void Atualizar(int id, especialidade especialidadeAtualizada)
        {
            //Busca uma especialidade pelo seu id
            especialidade especialidadeBuscada = BuscarPorId(id);

            //Verifica se o nome da especialidade foi informada
            if (especialidadeBuscada.nome != null)
            {
                //Caso tenha sido, atribui o novo valor ao campo
                especialidadeBuscada.nome = especialidadeAtualizada.nome;
            }

            //Atualiza a especialidade que foi buscada
            ctx.especialidades.Update(especialidadeBuscada);

            //Salva as informações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca uma especialidade pelo seu id
        /// </summary>
        /// <param name="id">Id da especialidade que será buscada</param>
        /// <returns>A especialidade buscada</returns>
        public especialidade BuscarPorId(int id)
        {
            //Retorna a especialidade encontrada
            return ctx.especialidades.Find(id);
        }

        /// <summary>
        /// Cadastra uma nova especialidade
        /// </summary>
        /// <param name="novaEspecialidade">Objeto com as informações que serão cadastradas</param>
        public void Cadastrar(especialidade novaEspecialidade)
        {
            //Adiciona a novaEspecialidade
            ctx.especialidades.Add(novaEspecialidade);

            //Salva as informações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta uma especialidade existente
        /// </summary>
        /// <param name="id">Id da especialidade que será deletada</param>
        public void Deletar(int id)
        {
            //Busca a habilidade pelo seu id
            especialidade especialidadeBuscada = BuscarPorId(id);

            //Remove a especialidade que foi buscada
            ctx.especialidades.Remove(especialidadeBuscada);

            //Salva as alterações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todas as especialidades
        /// </summary>
        /// <returns>Uma lista de especialidade</returns>
        public List<especialidade> Listar()
        {
            //Retorna uma lista com todas as informações das especialidades
            return ctx.especialidades.ToList();
        }

        /// <summary>
        /// Lista todas as especialidade e os médicos que à tem
        /// </summary>
        /// <returns>Uma lista de especialidade com os médicos</returns>
        public List<especialidade> ListarMedicos()
        {
            //Retorna uma lista de especialidade com os médicos
            return ctx.especialidades.Include(e => e.medicos).ToList();
        }
    }
}
