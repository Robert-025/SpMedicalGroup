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
    public class ClinicaRepository : IClinicaRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        SpMedicalGroupContext ctx = new SpMedicalGroupContext();

        /// <summary>
        /// Atualiza uma clínica passando seu id na url da requisição
        /// </summary>
        /// <param name="id">Id da clínica que será atualizada</param>
        /// <param name="clinicaAtualizada">Objeto com as informações informadas</param>
        public void Atualizar(int id, clinica clinicaAtualizada)
        {
            //Faz a busca pela clinica que vai ser atualizada
            clinica clinicaBuscada = BuscarPorId(id);

            //Verifica se o campo razaoSocial novo foi informado
            if (clinicaBuscada.razaoSocial != null)
            {
                //Caso tenha sido, atribui o novo valor ao campo
                clinicaBuscada.razaoSocial = clinicaAtualizada.razaoSocial;
            }

            //Verifica se o campo nomeClinica novo foi informado
            if (clinicaBuscada.nomeClinica != null)
            {
                //Caso tenha sido, atribui o novo valor ao campo
                clinicaBuscada.nomeClinica = clinicaAtualizada.nomeClinica;
            }

            //Verifica se o campo endereco novo foi informado
            if (clinicaBuscada.endereco != null)
            {
                //Caso tenha sido, atribui o novo valor ao campo
                clinicaBuscada.endereco = clinicaAtualizada.endereco;
            }

            //Verifica se o campo cnpj novo foi informado
            if (clinicaBuscada.cnpj != null)
            {
                //Caso tenha sido, atribui o novo valor ao campo
                clinicaBuscada.cnpj = clinicaAtualizada.cnpj;
            }

            //Verifica se o campo horarioAbertura novo foi informado
            if (clinicaBuscada.horarioAbertura != null)
            {
                //Caso tenha sido, atribui o novo valor ao campo
                clinicaBuscada.horarioAbertura = clinicaAtualizada.horarioAbertura;
            }

            //Verifica se o campo horarioFechamento novo foi informado
            if (clinicaBuscada.horarioFechamento != null)
            {
                //Caso tenha sido, atribui o novo valor ao campo
                clinicaBuscada.horarioFechamento = clinicaAtualizada.horarioFechamento;
            }

            //Atualiza a clinicaBuscada
            ctx.clinicas.Update(clinicaBuscada);

            //Salva as alterações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca uma clínica pelo seu id
        /// </summary>
        /// <param name="id">Id da clinica que vai ser buscada</param>
        /// <returns>A clinica buscada</returns>
        public clinica BuscarPorId(int id)
        {
            //Retorna a clinica buscada
            return ctx.clinicas.Find(id);
        }

        /// <summary>
        /// Cadastra uma nova clínica
        /// </summary>
        /// <param name="novaClinica">Objeto com as informações que serão cadastradas</param>
        public void Cadastrar(clinica novaClinica)
        {
            //Adiciona a novaClinica
            ctx.clinicas.Add(novaClinica);

            //Salva as informações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta uma clínica existente
        /// </summary>
        /// <param name="id">Id da clínica que será deletada</param>
        public void Deletar(int id)
        {
            //Busca a clínica de acordo com o id informado
            clinica clinicaBuscada = BuscarPorId(id);

            //Remove a clinica que foi buscada
            ctx.clinicas.Remove(clinicaBuscada);

            //Salva as alterações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todas as clínicas
        /// </summary>
        /// <returns>Uma lista de clínicas</returns>
        public List<clinica> Listar()
        {
            //Retorna uma lista com todas as clinicas
            return ctx.clinicas.ToList();
        }

        /// <summary>
        /// Lista todas as clínicas e os médicos que pertencem a ela
        /// </summary>
        /// <returns>Uma lista de clínicas com os médicos</returns>
        public List<clinica> ListarMedicos()
        {
            //Retorna a lista de clinicas incluindo os médicos
            return ctx.clinicas.Include(c => c.medicos).ToList();
        }
    }
}
