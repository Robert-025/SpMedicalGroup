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
    public class MedicoRepository : IMedicoRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        SpMedicalGroupContext ctx = new SpMedicalGroupContext();

        /// <summary>
        /// Atualiza um médico passando seu id na url da requisição
        /// </summary>
        /// <param name="id">Id do médico que será atualizado</param>
        /// <param name="medicoAtualizado">Objeto com as informações a serem gravadas</param>
        public void Atualizar(int id, medico medicoAtualizado)
        {
            //Busca o médico que será atualizado passando o seu id
            medico medicoBuscado = BuscarPorId(id);

            // IF -> Verifica se o atributo do medico foi informado

            // xx.xx = yy.xx -> Atribui o valor informado ao medico que será atualizado

            if (medicoAtualizado.crm != null)
            {
                medicoBuscado.crm = medicoAtualizado.crm;
            }

            if (medicoAtualizado.idEspecialidade > 0)
            {
                medicoBuscado.idEspecialidade = medicoAtualizado.idEspecialidade;
            }

            if (medicoAtualizado.idClinica > 0)
            {
                medicoBuscado.idClinica = medicoAtualizado.idClinica;
            }

            //Atualiza o medicoBuscado na lista de medicos
            ctx.medicos.Update(medicoBuscado);

            //Salva as alterações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um médico pelo seu id
        /// </summary>
        /// <param name="id">Id do médico que será buscado</param>
        /// <returns>O médico buscado</returns>
        public medico BuscarPorId(int id)
        {
            //Busca dentro da lista medicos o id pedido
            return ctx.medicos.Find(id);
        }

        /// <summary>
        /// Cadastra um novo médico
        /// </summary>
        /// <param name="novoMedico">Objeto com </param>
        public void Cadastrar(medico novoMedico)
        {
            //Adiciona o novoMedico a list de medicos 
            ctx.medicos.Add(novoMedico);

            //Salva as informações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um médico pelo seu id
        /// </summary>
        /// <param name="id">Id do médico que sérá deletado</param>
        public void Deletar(int id)
        {
            //Remove o médicoque está sendo buscado da lista de medicos
            ctx.medicos.Remove(BuscarPorId(id));

            //Salva as alterações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista os médicos com as clínicas a que ele pertence
        /// </summary>
        /// <returns>A lista de médicos com as clínicas</returns>
        public List<medico> ListarClinica()
        {
            //Retorna a lista de médicos incluindo os atriubutos de clinica atrelados ao médico
            return ctx.medicos.Include(m => m.idClinicaNavigation).ToList();
        }

        /// <summary>
        /// Lista os médicos com as consultas atreladas a eles
        /// </summary>
        /// <returns>
        /// A lista de médicos com as consultas</returns>
        public List<medico> ListarConsulta()
        {
            //Retorna a lista de médicos incluindo os atriubutos de consuulta atrelados ao médico
            return ctx.medicos.Include(m => m.consulta).ToList();
        }

        /// <summary>
        /// Lista os médicos e as suas especialidades
        /// </summary>
        /// <returns>A lista de médicos com as suas especialidades</returns>
        public List<medico> ListarEspecialidade()
        {
            //Retorna a lista de médicos incluindo os atriubutos de especialidades atrelados ao médico
            return ctx.medicos.Include(m => m.idEspecialidadeNavigation).ToList();
        }

        /// <summary>
        /// Lista todos os médicos com seus atributos de usuarios incluídos
        /// </summary>
        /// <returns>Uma lista de médicos com os atributos de usuario incluídos</returns>
        public List<medico> ListarMedicos()
        {
            //Retorna a lista de médicos incluindo os atributos de usuario que estão atrelados ao médico
            return ctx.medicos.Include(m => m.idUsuarioNavigation).ToList();
        }
    }
}
