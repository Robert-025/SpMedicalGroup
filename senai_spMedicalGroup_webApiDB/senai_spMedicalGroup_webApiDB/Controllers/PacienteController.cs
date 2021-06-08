using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_spMedicalGroup_webApiDB.Domains;
using senai_spMedicalGroup_webApiDB.Interfaces;
using senai_spMedicalGroup_webApiDB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spMedicalGroup_webApiDB.Controllers
{
    //Define que a resposta da API é em JSON
    [Produces("application/json")]

    //Define a rota padrão da requisição -> dominio/api/nomeController
    [Route("api/[controller]")]

    //Define que é um controlador API
    [ApiController]
    public class PacienteController : ControllerBase
    {
        /// <summary>
        /// Instancia o IPacienteRepository para ter acesso aos métodos criados nele
        /// </summary>
        IPacienteRepository _pacienteRepository { get; set; }

        public PacienteController()
        {
            //Atribui o _pacienteRepository ao PacienteRepository para ter referências aos métodos lá montados
            _pacienteRepository = new PacienteRepository();
        }

        /// <summary>
        /// Lista as consultas juntamente com as características de usuarios atreladas aos pacientes
        /// </summary>
        /// <returns>Retorna um status code 200 - Ok com a lista de pacientes e as consultas</returns>
        [HttpGet("consultas")]
        public IActionResult GetConsulta()
        {
            try
            {
                //Retorna o status code e a lista
                return Ok(_pacienteRepository.ListarConsultas());
            }
            catch (Exception ex)
            {
                //Retorna o status code com o código de erro
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Lista todos os pacientes
        /// </summary>
        /// <returns>Um status code 200 - Ok com a lista de pacientes</returns>
        [HttpGet]
        public IActionResult GetPacientes()
        {
            try
            {
                //Retorna o status code e a lista
                return Ok(_pacienteRepository.ListarPaciente());
            }
            catch (Exception ex)
            {
                //Retorna o status code com o código de erro
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Busca um paciente pelo seu id
        /// </summary>
        /// <param name="id">Id do paciente que será buscado</param>
        /// <returns>Um status code 200 - OK com o paciente buscado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_pacienteRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                //Retorna o status code com o código de erro
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Deleta um paciente existente passando seu id na url
        /// </summary>
        /// <param name="id">Id do paciente que será deletado</param>
        /// <returns>Um status code 204 - NoContent</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                //Chama o método de deletar passando o id informado na requisição 
                _pacienteRepository.Deletar(id);

                //Retorna o status code
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                //Retorna o status code com o código de erro
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Cadastra um novo paciente
        /// </summary>
        /// <param name="novoPaciente">Objeto com as informações que seão cadastradas</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(paciente novoPaciente)
        {
            try
            {
                //Chama o método de cadastrar passando o novoPaciente
                _pacienteRepository.Cadastrar(novoPaciente);

                //Retorna o status code
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                //Retorna o status code com o código de erro
                return BadRequest(ex);
            }

        }

        /// <summary>
        /// Atualiza um paciente passando seu id na url
        /// </summary>
        /// <param name="id">Id do paciente que será atualizado</param>
        /// <param name="pacienteAtualizado">Objeto com as novas informações</param>
        /// <returns>Um status code 204 - NoContent</returns>
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, paciente pacienteAtualizado)
        {
            try
            {
                _pacienteRepository.Atualizar(id, pacienteAtualizado);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                //Retorna o status code com o código de erro
                return BadRequest(ex);
            }
        }
    }
}
