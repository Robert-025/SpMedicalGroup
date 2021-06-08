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
    public class SituacaoController : ControllerBase
    {
        /// <summary>
        /// Instancia o ISituacaoRepository para ter acesso aos métodos criados nele
        /// </summary>
        ISituacaoRepository _situacaoRepository { get; set; }

        public SituacaoController()
        {
            //Atribui o _situacaoRepository ao PacienteRepository para ter referências aos métodos lá montados
            _situacaoRepository = new SituacaoRepository();
        }

        /// <summary>
        /// Lista todas as situações
        /// </summary>
        /// <returns>Um status code 200 - OK com a lista de situações</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Retorna o status code com a lista de situações
                return Ok(_situacaoRepository.Listar());
            }
            catch (Exception ex)
            {
                //Retorna o status code com o código de erro
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// BUsca uma situação pelo seu ID
        /// </summary>
        /// <param name="id">ID da situação que será buscada</param>
        /// <returns>Um status code 200 - OK com a situação buscada</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //Retorna o status code com a situação buscada
            return Ok(_situacaoRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Atualiza uma situação passando seu ID na url
        /// </summary>
        /// <param name="id">ID da situação que será atualizada</param>
        /// <param name="situacaoAtualizada">Objeto com as novas informações</param>
        /// <returns>Um status code 204 - NoContent</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, situacao situacaoAtualizada)
        {
            try
            {
                //Chama o método de atualizar
                _situacaoRepository.Atualizar(id, situacaoAtualizada);

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
        /// Cadastra uma nova situação
        /// </summary>
        /// <param name="novaSituacao">Objeto com as informações a serem cadastradas</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(situacao novaSituacao)
        {
            try
            {
                //Chama o método de cadastrar
                _situacaoRepository.Cadastrar(novaSituacao);

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
        /// Deleta uma situação existente
        /// </summary>
        /// <param name="id">ID da situação que será deletada</param>
        /// <returns>Um status code 204 - NoContent</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                //Chama o método de deletar
                _situacaoRepository.Deletar(id);

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
