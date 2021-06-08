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
    public class PacienteRepository : IPacienteRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        SpMedicalGroupContext ctx = new SpMedicalGroupContext();

        /// <summary>
        /// Atualiza um paciente passando seu id na url da requisição
        /// </summary>
        /// <param name="id">Id do paciente que será atualizado</param>
        /// <param name="pacienteAtualizado">Objeto com as informações que serão atualizadas</param>
        public void Atualizar(int id, paciente pacienteAtualizado)
        {
            //Busca o paciente que será atualizado pelo seu id
            paciente pacienteBuscado = BuscarPorId(id);

            // IF -> Verifica se o atributo do paciente foi informado

            // xx.xx = yy.xx -> Atribui o valor informado ao paciente que será atualizado

            if (pacienteAtualizado.telefone != null)
            {
                pacienteBuscado.telefone = pacienteAtualizado.telefone;
            }

            if (pacienteAtualizado.rg != null)
            {
                pacienteBuscado.rg = pacienteAtualizado.rg;
            }

            if (pacienteAtualizado.cpf != null)
            {
                pacienteBuscado.cpf = pacienteAtualizado.cpf;
            }

            if (pacienteAtualizado.endereco != null)
            {
                pacienteBuscado.endereco = pacienteAtualizado.endereco;
            }

            //Atualiza o objeto com as novas informações
            ctx.pacientes.Update(pacienteBuscado);

            //Salva as alterações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um paciente pelo seu id
        /// </summary>
        /// <param name="id">Id do paciente que será buscado</param>
        /// <returns>O paciente buscado</returns>
        public paciente BuscarPorId(int id)
        {
            return ctx.pacientes.Find(id);
        }

        /// <summary>
        /// Cadastra um novo paciente
        /// </summary>
        /// <param name="novoPaciente">Objeto com as informações que serão cadastradas</param>
        public void Cadastrar(paciente novoPaciente)
        {
            //Adiciona o novoPaciente a lista de pacientes
            ctx.pacientes.Add(novoPaciente);

            //Salva as informações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um paciente existente
        /// </summary>
        /// <param name="id">Id do paciente que será deletado</param>
        public void Deletar(int id)
        {
            //Remove o paciente da lista de pacientes buscado ele e tirando
            ctx.pacientes.Remove(BuscarPorId(id));

            //Salva as alterações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista os pacientes com suas consultas
        /// </summary>
        /// <returns>Uma lista de consultas</returns>
        public List<paciente> ListarConsultas()
        {
            //Retorna a lista de pacientes 
            ctx.pacientes.Include(p => p.idUsuarioNavigation).ToList();            
            return ctx.pacientes.Include(p => p.consulta).ToList();
        }

        /// <summary>
        /// Lista todos os pacientes com suas características de usuario
        /// </summary>
        /// <returns>Uma lista de pacientes</returns>
        public List<paciente> ListarPaciente()
        {
            //Retorna a lista de pacientes com as características de usuário
            return ctx.pacientes.Include(p => p.idUsuarioNavigation).ToList();
        }
    }
}
