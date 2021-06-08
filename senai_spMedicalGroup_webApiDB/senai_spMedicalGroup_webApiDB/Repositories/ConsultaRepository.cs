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
    public class ConsultaRepository : IConsultaRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        SpMedicalGroupContext ctx = new SpMedicalGroupContext();

        /// <summary>
        /// Altera o status de uma consulta
        /// </summary>
        /// <param name="id">Id da consulta que terá sua situação alterada</param>
        /// <param name="status">Parâmetro que atualiza a situação da consulta para -> 1 - Agendada, - Realizada e 3 - Cancelada</param>
        public void AprovarRecusar(int id, string status)
        {
            // Busca a primeira presença para o ID informado e armazena no objeto consultaBuscada
            consulta consultaBuscada = ctx.consultas

                //Adiciona na busca as informações do paciente que participa da consulta
                .Include(c => c.idPacienteNavigation)
                
                //Adiciona na busca as informações do médico que participa da consulta
                .Include(c => c.idMedicoNavigation)

                //Adiciona na busca as informações da situação da consulta
                .Include(c => c.idSituacaoNavigation)

                //Método que procura na lista idConsulta a consulta com o ID informado
                .FirstOrDefault(c => c.idConsulta == id);

            switch (status)
            {
                //Se for 1, a situação da consulta será "Agendada"
                case "1":
                    consultaBuscada.idSituacao = 1;
                  break;

                //Se for 2, a situação da consulta será "Realizada"
                case "2":
                    consultaBuscada.idSituacao = 2;
                  break;

                //Se for 3, a situação da consulta será "Cancelada"
                case "3":
                    consultaBuscada.idSituacao = 3;
                  break;

                //Se for agendada, a situação da consulta será "Agendada" = 1
                case "Agendada":
                    consultaBuscada.idSituacao = 1;
                  break;

                //Se for realizada, a situação da consulta será "Realizada" = 2
                case "Realizada":
                    consultaBuscada.idSituacao = 2;
                  break;

                //Se for cancelada, a situação da consulta será "Cancelada" = 3
                case "Cancelada":
                    consultaBuscada.idSituacao = 3;
                  break;

                //Se for qualquer valor diferente de 1, 2 e 3 a situação da consulta não será alterada
                default:
                    consultaBuscada.idSituacao = consultaBuscada.idSituacao;
                  break;
            }

            //Atualiza a consultaBuscada com as novas informações passadas
            ctx.consultas.Update(consultaBuscada);

            //Salva as alterações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Atualiza uma consulta existente
        /// </summary>
        /// <param name="id">Id da consulta que será atualizada</param>
        /// <param name="consultaAtualizada">Objeto com as novas informações</param>
        public void Atualizar(int id, consulta consultaAtualizada)
        {

            //Busca a consulta que será atualizada
            consulta consultaBuscada = BuscarPorId(id);

            // IF -> Verifica se o atributo do paciente foi informado

            // xx.xx = yy.xx -> Atribui o valor informado ao paciente que será atualizado

            if (consultaAtualizada.idPaciente != null)
            {
                consultaBuscada.idPaciente = consultaAtualizada.idPaciente;
            }

            if (consultaAtualizada.idMedico != null)
            {
                consultaBuscada.idMedico = consultaAtualizada.idMedico;
            }

            if (consultaAtualizada.dataConsulta.ToString() != null)
            {
                consultaAtualizada.dataConsulta = consultaBuscada.dataConsulta;
            }

            if (consultaAtualizada.idSituacao != null)
            {
                consultaAtualizada.idSituacao = consultaBuscada.idSituacao;
            }

            //Atualiza o objeto com as novas informações
            ctx.consultas.Update(consultaBuscada);

            //Salva as informações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca uma consulta pelo seu id
        /// </summary>
        /// <param name="id">Id da consulta que será buscada</param>
        /// <returns>A consulta buscada</returns>
        public consulta BuscarPorId(int id)
        {
            //Retorna a consulta encontrada
            return ctx.consultas.Find(id);
        }

        /// <summary>
        /// Busca um médico pelo seu nome para inserir ele no cadastro da consulta
        /// </summary>
        /// <param name="crmMedico">Nome do médico que será atrelado a consulta</param>
        /// <returns>O médico buscado</returns>
        public medico BuscarPorNome(string crmMedico)
        {
            //Procura no lista médicos um médico com o nome informado
            return ctx.medicos.FirstOrDefault(n => n.crm == crmMedico);
        }


        /// <summary>
        /// Busca um paciente pelo seu rg
        /// </summary>
        /// <param name="cpf">RG do paciente que será buscado</param>
        /// <returns>O paciente buscado</returns>
        public paciente BuscarPorRg(string cpf)
        {
            //Procura na lista pacientes um RG como o informado
            return ctx.pacientes.First(p => p.cpf == cpf);
        }

        /// <summary>
        /// Cadastra uma nova consulta
        /// </summary>
        /// <param name="novaConsulta">Objeto com as informações que serão cadastradas</param>
        public void Cadastrar(consulta novaConsulta)
        {
            //Adiciona na lista consultas o objeto com as informações passadas
            ctx.consultas.Add(novaConsulta);

            //Salva no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta uma consulta passadno seu id na url da requisição
        /// </summary>
        /// <param name="id">Id da consulta que será deletada</param>
        public void Deletar(int id)
        {
            //Busca na lista consultas pelo ID e remove
            ctx.consultas.Remove(BuscarPorId(id));

            //Salva as alterações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Cria uma nova consulta
        /// </summary>
        /// <param name="consulta">Objeto com as informãções da consulta</param>
        public void Inscrever(consulta consulta)
        {
            //Outra forma: Caso os dados da inscrição sejam enviados pelo usuário o idSituação  será sempre 1,
            //independente do status que o usuario tentar cadastrar
            //idSituacao = 1 = "Agendada "
            consulta.idSituacao = 1;

            //Adiciona a consulta informada na lista consultas
            ctx.consultas.Add(consulta);

            //Salva as informações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todas as consultas cadastradas
        /// </summary>
        /// <returns>Uma lista com as consultas</returns>
        public List<consulta> ListarConsultas()
        {
            //Retorna a lista de consultas
            return ctx.consultas.ToList();
        }

        /// <summary>
        /// Lista todas as consultas que um determinado usuario participa
        /// </summary>
        /// <param name="id">Id do usuario que participa das consultas listados</param>
        /// <returns>Uma lista de consultas com os dados da consulta</returns>
        public List<consulta> ListarMinhas(int id)
        {
            //Retorna uma lista com todas as informações das consultas
            return ctx.consultas
                    //Adiciona na busca as informações do médico que fará a consulta
                    .Include(c => c.idMedicoNavigation)
                    //Adiciona na busca as informações da especialidade do médico que fará a consulta
                    .Include(c => c.idMedicoNavigation.idEspecialidadeNavigation)
                    //Adiciona na busca as informações da clínica que o médico pertence
                    .Include(c => c.idMedicoNavigation.idClinicaNavigation)
                    //Estabelece como parâmetro de consulta o ID do usuario recebido
                    .Where(c => c.idPaciente == id)
                    .ToList();
        }
    }
}
