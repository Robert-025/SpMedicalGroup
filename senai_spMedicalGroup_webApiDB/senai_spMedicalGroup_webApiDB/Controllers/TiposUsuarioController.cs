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
{
    //Define que a resposta da API é em JSON
    [Produces("application/json")]

    //Define a rota padrão da requisição -> dominio/api/nomeController
    [Route("api/[controller]")]

    //Define que é um controlador API
    [ApiController]
    public class TiposUsuarioController : ControllerBase
    {
        /// <summary>
        /// Instancia o ITiposUsuarioRepository para ter acesso aos métodos criados nele
        /// </summary>
        ITiposUsuarioRepository _tiposUsuarioRepository { get; set; }

        public TiposUsuarioController()
        {
            //Atribui o _tiposUsuarioRepository ao TiposUsuarioRepository para ter referências aos métodos lá montados
            _tiposUsuarioRepository = new TiposUsuarioRepository();
        }

        /// <summary>
        /// Lista todos os tipos de usuarios
        /// </summary>
        /// <returns>A lista com os tipos de usuarios junto do status code 200 - OK</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Retorna o status code e a lista de especialidades
                return Ok(_tiposUsuarioRepository.Listar());
            }
            catch (Exception ex)
            {
                //Retorna o status code com o código de erro
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Busca um tipo de usuario pelo seu id 
        /// </summary>
        /// <param name="id">Id do tipo de usuario que será buscado</param>
        /// <returns>Um status code 200 - Ok com o tipo de usuario buscado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_tiposUsuarioRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                //Retorna o status code com o código de erro
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Lista os tipos de usuarios com os usuarios atrelados a eles
        /// </summary>
        /// <returns>Um status code 200 - OK com a lista de tipos de usuarios com seus usuarios </returns>
        [HttpGet("usuarios")]
        public IActionResult GetUsuarios()
        {
            try
            {
                return Ok(_tiposUsuarioRepository.ListarUsuarios());
            }
            catch (Exception ex)
            {
                //Retorna o status code com o código de erro
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Deleta um tipo de usuario pelo seu id
        /// </summary>
        /// <param name="id">Id do tipo de usuario que vai ser deletado</param>
        /// <returns>Um status code 204 - NoContent</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                //Chama o método de deletar criado no repository
                _tiposUsuarioRepository.Deletar(id);

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
        /// Cadastra um novo tipo de usuario
        /// </summary>
        /// <param name="novoTipo">Objeto com as informações que serão cadastradas</param>
        /// <returns>Um status code 201 - Created</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(tiposUsuario novoTipo)
        {
            try
            {
                //Chama o método de cadastrar passando o novoTipo
                _tiposUsuarioRepository.Cadastrar(novoTipo);

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
        /// Atualiza um tipo de usuario passando seu id na url
        /// </summary>
        /// <param name="id">Id do tipo de usuario que será atualizado</param>
        /// <param name="tipoAtualizado">Objeto com as novas informações</param>
        /// <returns>Um status code 204 - NoContent</returns>
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, tiposUsuario tipoAtualizado)
        {
            try
            {
                //Chama o método de atualizar passando o id e o tipoAtualizado que foram informados na requisição
                _tiposUsuarioRepository.Atualizar(id, tipoAtualizado);

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
