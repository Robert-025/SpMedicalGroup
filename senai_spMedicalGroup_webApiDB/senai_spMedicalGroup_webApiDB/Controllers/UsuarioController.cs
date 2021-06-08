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
    public class UsuarioController : ControllerBase
    {
        /// <summary>
        /// Instancia o IUsuarioRepository para ter acesso aos métodos criados nele
        /// </summary>
        IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            //Atribui o _usuarioRepository ao UsuarioRepository para ter referências aos métodos lá montados
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Lista todos os usuarios
        /// </summary>
        /// <returns>Um status code 200 - OK com a lista de usuarios</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Retorna o status code e a lista
                return Ok(_usuarioRepository.Listar());
            }
            catch (Exception ex)
            {
                //Retorna o status code com o código de erro
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Busca um usuario pelo seu id
        /// </summary>
        /// <param name="id">Id do usuario que será buscado</param>
        /// <returns>Um status code 200 - OK com o usuario buscado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                //Retorna o status code e o usuario buscado
                return Ok(_usuarioRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                //Retorna o status code com o código de erro
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Lista os usuario com os tipos atrelados a eles
        /// </summary>
        /// <returns>Um status code 200 - OK com a lista de usuarios e os tipos</returns>
        [HttpGet("tipos")]
        public IActionResult GetTipos()
        {
            try
            {
                //Retorna o status code e a lista
                return Ok(_usuarioRepository.ListarTipo());
            }
            catch (Exception ex)
            {
                //Retorna o status code com o código de erro
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Lista todos os usuario e os pacientes que estão atrelados a ele
        /// </summary>
        /// <returns>Um status code 200 - OK com a lista de usuarios e os pacientes atrelados</returns>
        [HttpGet("pacientes")]
        public IActionResult GetPacientes()
        {
            try
            {
                //Retorna o status code e a lista
                return Ok(_usuarioRepository.ListarPacientes());
            }
            catch (Exception ex)
            {
                //Retorna o status code com o código de erro
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Lista os usuarios e os médicos que estão atrelados a eles
        /// </summary>
        /// <returns>Um status code 200 - OK com a lista de usuarios e os médiocs</returns>
        [HttpGet("medicos")]
        public IActionResult GetMedicos()
        {
            try
            {
                //Retorna o status code e a lista
                return Ok(_usuarioRepository.ListarMedicos());
            }
            catch (Exception ex)
            {
                //Retorna o status code com o código de erro
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="novoUsuario">Objeto com as informações que serão cadastradas</param>
        /// <returns>Um status code 204 - NoContent</returns>
        [HttpPost]
        public IActionResult Post(usuario novoUsuario)
        {
            try
            {
                //Chama o método de cadastrar passando o novoUsuario passado como parâmetro
                _usuarioRepository.Cadastrar(novoUsuario);

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
        /// Deleta um usuario existente passando seu id na url da requisição
        /// </summary>
        /// <param name="id">Id do usuario que serpa deletado</param>
        /// <returns>Um status code 204 - NoContent</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                //Chama o método de deletar passando o id informado na requisição
                _usuarioRepository.Deletar(id);

                //Retorna o status code
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                //Retorna o status code com o código de erro
                return BadRequest(ex);
            }
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, usuario usuarioAtualizado)
        {
            try
            {
                //Chama o método de atualizar passando o id e o objeto como parâmetros
                _usuarioRepository.Atualizar(id, usuarioAtualizado);

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
