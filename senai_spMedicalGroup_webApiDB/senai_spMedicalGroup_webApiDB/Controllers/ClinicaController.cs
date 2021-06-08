using Microsoft.AspNetCore.Authorization;
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
{//Define que a resposta da API é em JSON
    [Produces("application/json")]

    //Define a rota padrão da requisição -> dominio/api/nomeController
    [Route("api/[controller]")]

    //Define que é um controlador API
    [ApiController]
    public class ClinicaController : ControllerBase
    {
        /// <summary>
        /// Instancia o IClinicaRepository para ter acesso aos métodos criados nele
        /// </summary>
        IClinicaRepository _clinicaRepository { get; set; }

        public ClinicaController()
        {
            //Atribui o _clinicaRepository ao ClinicaRepository para ter referências aos métodos lá montados
            _clinicaRepository = new ClinicaRepository();
        }

        /// <summary>
        /// Lista todas as clínicas
        /// </summary>
        /// <returns>Um status code 200 - OK com a lista de clínicas</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Retorna o status code e a lista
                return Ok(_clinicaRepository.Listar());
            }
            catch (Exception ex)
            {
                //Retorna o status code com o código de erro
                return BadRequest(ex);
            }            
        }

        /// <summary>
        /// Busca uma clínica pelo seu id
        /// </summary>
        /// <param name="id">Id da clínica que será buscada</param>
        /// <returns>Um status code 200 - OK com a clínica buscada</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                //Retorna o status code e a clínica 
                return Ok(_clinicaRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                //Retorna o status code com o código de erro
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Lista as clínicas e seus médicos
        /// </summary>
        /// <returns>Um status code 200 - OK com uma lista de clínicas e seus médicos</returns>
        [HttpGet("medicos")]
        public IActionResult GetMedicos()
        {
            try
            {
                //Retorna o status code e a lista
                return Ok(_clinicaRepository.ListarMedicos());
            }
            catch (Exception ex)
            {
                //Retorna o status code com o código de erro
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Cadastra uma nova clínica
        /// </summary>
        /// <param name="novaClinica">Objeto com as informações que serão cadastradas</param>
        /// <returns>Um status code 201 - Created</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(clinica novaClinica)
        {
            try
            {
                //Chama o método de cadastrar
                _clinicaRepository.Cadastrar(novaClinica);

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
        /// Deleta uma clínica existente
        /// </summary>
        /// <param name="id">Id da clínica que será deletada</param>
        /// <returns>Um status code 204 - NoContent</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                //Chama o método de deletar
                _clinicaRepository.Deletar(id);

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
        /// Atualiza uma clínica passando seu id na url
        /// </summary>
        /// <param name="id">Id da clínica que será atualizada</param>
        /// <param name="clinicaAtualizada">Objeto com as novas informações</param>
        /// <returns>Um status code 204 - NoContent</returns>
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, clinica clinicaAtualizada)
        {
            try
            {
                //Chama o método de atualizar 
                _clinicaRepository.Atualizar(id, clinicaAtualizada);

                //Retorna o status code
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
