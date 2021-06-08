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
    public class EspecialidadeController : ControllerBase
    {
        /// <summary>
        /// Instancia o IEspecialidadeRepository para ter acesso aos métodos criados nele
        /// </summary>
        IEspecialidadeRepository _especialidadeRepository { get; set; }

        public EspecialidadeController()
        {
            //Atribui o _especialidadeRepository ao EstudioRepository para ter referências aos métodos lá montados
            _especialidadeRepository = new EspecialidadeRepository();
        }

        /// <summary>
        /// Lista todas as especialidades
        /// </summary>
        /// <returns>Um status code 200 - OK com a lista</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Retorna o status code e a lista de especialidades
                return Ok(_especialidadeRepository.Listar());
            }
            catch (Exception ex)
            {
                //Retorna o status code com o código de erro
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Busca uma especialidade pelo seu id 
        /// </summary>
        /// <param name="id">Id da especialidade que será buscada</param>
        /// <returns>Um status code 200 - Ok com a especialidade buscada</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                //Retorna o status code e a especialidade
                return Ok(_especialidadeRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                //Retorna o status code com o código de erro
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Lista todas as especialidades e os médicos atrelados a cada uma delas
        /// </summary>
        /// <returns>Um status code 200 - OK com a lista</returns>
        [HttpGet("medicos")]
        public IActionResult GetMedicos()
        {
            try
            {
                //Retorna o status code e a lista de especialidades com os médicos
                return Ok(_especialidadeRepository.ListarMedicos());
            }
            catch (Exception ex)
            {
                //Retorna o status code com o código de erro
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Deleta uma especialidade existente
        /// </summary>
        /// <param name="id">Id da especialidade que será deletada</param>
        /// <returns>Uma status code 204 - NoContent</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                //Chama o método de deletar criado no repository
                _especialidadeRepository.Deletar(id);

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
        /// Cadastra uma nova especialidade
        /// </summary>
        /// <param name="novaEspecialidade">Objeto com as informações que serão cadastradas</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(especialidade novaEspecialidade)
        {
            try
            {
                //Cadastra a novaEspecialidade
                _especialidadeRepository.Cadastrar(novaEspecialidade);

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
        /// Atualiza todos os parâmetros da especialidade
        /// </summary>
        /// <param name="id">Id da especialidade que será atualizada</param>
        /// <param name="especialidadeAtualizada">Objeto com as novas informações</param>
        /// <returns>Um status code 204 - NoContente</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, especialidade especialidadeAtualizada)
        {
            try
            {
                //Chama o método de atualizar
                _especialidadeRepository.Atualizar(id, especialidadeAtualizada);

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
