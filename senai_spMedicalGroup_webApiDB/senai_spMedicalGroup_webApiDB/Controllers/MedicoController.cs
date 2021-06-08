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
    public class MedicoController : ControllerBase
    {
        /// <summary>
        /// Instancia o IMedicoRepository para ter acesso aos métodos criados nele
        /// </summary>
        IMedicoRepository _medicoRepository { get; set; }

        public MedicoController()
        {
            //Atribui o _medicoRepository ao MedicoRepository para ter referências aos métodos lá montados
            _medicoRepository = new MedicoRepository();
        }

        /// <summary>
        /// Lista todos os médicos com os atributos de usuarios que estão atrelados a eles
        /// </summary>
        /// <returns>Um status code 200 - OK com a lista</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Retorna o status code com a lista
                return Ok(_medicoRepository.ListarMedicos());
            }
            catch (Exception ex)
            {
                //Retorna o status code com o código de erro
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Busca um médico pelo seu id
        /// </summary>
        /// <param name="id">Id do médico que será buscado</param>
        /// <returns>Um status code 200 - OK com o médico buscado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                //Retorna o status code com o método
                return Ok(_medicoRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                //Retorna o status code com o código de erro
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Lista os médicos e as clínicas que eles pertencem
        /// </summary>
        /// <returns>Um status code 200 - OK com uja lista de médicos com as clínicas</returns>
        [HttpGet("clinicas")]
        public IActionResult GetClinicas()
        {
            try
            {
                //Retorna o status code com a lista
                return Ok(_medicoRepository.ListarClinica());
            }
            catch (Exception ex)
            {
                //Retorna o status code com o código de erro
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Lista os médicos com as consultas atreladas a ele
        /// </summary>
        /// <returns>Um status code 200 - OK com uma lista de médicos e as suas consultas</returns>
        [HttpGet("consultas")]
        public IActionResult GetConsultas()
        {
            try
            {
                //Retorna o status code com a lista
                return Ok(_medicoRepository.ListarConsulta());
            }
            catch (Exception ex)
            {
                //Retorna o status code com o código de erro
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Lista os médicos com as suas especialidades
        /// </summary>
        /// <returns>Um status code 200 - OK com a lista de médicos e suas especialidades</returns>
        [HttpGet("especialidades")]
        public IActionResult GetEspecialidade()
        {
            try
            {
                //Retorna o status code com a lista
                return Ok(_medicoRepository.ListarEspecialidade());
            }
            catch (Exception ex)
            {
                //Retorna o status code com o código de erro
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Deleta um médico existente
        /// </summary>
        /// <param name="id">Id do médico que será deletado</param>
        /// <returns>Um status code 204 - NoContent</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                //Chama o método de deletar
                _medicoRepository.Deletar(id);

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
        /// Cadastra um novo médico
        /// </summary>
        /// <param name="novoMedico">Objeto com as informações que serão cadastradas</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(medico novoMedico)
        {
            try
            {
                //Chama o método de cadastrar e cadastra o novoMedico
                _medicoRepository.Cadastrar(novoMedico);

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
        /// Atualiza um médico passando seu id na url
        /// </summary>
        /// <param name="id">Id do médico que será atualizado</param>
        /// <param name="medicoAtualizado">Objeto com as novas informações</param>
        /// <returns>Um status code 204 - NoContent</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, medico medicoAtualizado)
        {
            try
            {
                //Chama o método de atualizar passando o id do médico que será atualizado e o objeto com as novas informações
                _medicoRepository.Atualizar(id, medicoAtualizado);

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
