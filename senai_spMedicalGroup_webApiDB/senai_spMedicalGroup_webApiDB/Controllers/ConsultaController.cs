using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_spMedicalGroup_webApiDB.Domains;
using senai_spMedicalGroup_webApiDB.Interfaces;
using senai_spMedicalGroup_webApiDB.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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
    public class ConsultaController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber os métodos definidos na interface
        /// </summary>
        IConsultaRepository _consultaRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _consultaRepository para que haja referência aos métodos do repositorio
        /// </summary>
        public ConsultaController()
        {
            _consultaRepository = new ConsultaRepository();
        }

        /// <summary>
        /// Lista todas as consultas
        /// </summary>
        /// <returns>Um status code Ok - 200 com a lista de consultas</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Retorna o status code com a lista de consultas
                return Ok(_consultaRepository.ListarConsultas());
            }
            catch (Exception ex)
            {
                //Retorna um status code 400 - BadRequest com a exception
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Busca uma consulta pelo seu ID
        /// </summary>
        /// <param name="id">ID da consulta que será buscada</param>
        /// <returns>Um status code 200 - OK com a consulta</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_consultaRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                //Retorna um status code 400 - BadRequest com a exception
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Cadastra uma nova consulta
        /// </summary>
        /// <param name="novaConsulta">Objeto com as informações que serão cadastradas</param>
        /// <returns>Um status code 201 - Created</returns>
        [Authorize (Roles = "1")]
        [HttpPost]
        public IActionResult Post(consulta novaConsulta)
        {
            try
            {
                //Cadastra a novaConsulta pelo método do repository
                _consultaRepository.Cadastrar(novaConsulta);

                //Retorna o status code
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                //Retorna um status code 400 - BadRequest com a exception
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Atualiza todos os parâmetros de uma consulta
        /// </summary>
        /// <param name="id">ID da consulta que será atualizada</param>
        /// <param name="consultaAtualizada">Objeto com as novas informações</param>
        /// <returns>Um status code 204 - NoContent</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, consulta consultaAtualizada)
        {
            try
            {
                _consultaRepository.Atualizar(id, consultaAtualizada);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                //Retorna um status code 400 - BadRequest com a exception
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Deleta uma consulta passando seu id na url
        /// </summary>
        /// <param name="id">ID da consulta que será deletada</param>
        /// <returns>Um status code 204 - NoContent</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                //Chama o método de deletar passando o ID
                _consultaRepository.Deletar(id);

                //Retorna o status code
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                //Retorna um status code 400 - BadRequest com a exception
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Lista todas as consultas de um usuario
        /// </summary>
        /// <returns>Uma lista de consultas com um status code 200 - OK</returns>
        [Authorize(Roles = "2, 3")]
        [HttpGet("minhas")]
        public IActionResult GetMinhas()
        {
            try
            {
                // Cria uma variável idUsuario que recebe o valor do ID do usuário que está logado
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                // Retora a resposta da requisição 200 - OK fazendo a chamada para o método e trazendo a lista
                return Ok(_consultaRepository.ListarMinhas(idUsuario));
            }
            catch (Exception ex)
            {
                //Retorna um status code 400 - BadRequest com a exception
                return BadRequest(new { 
                    mensagem = "Não é possível mostrar as consultas se o usuário não estiver logado!",
                    ex
                });
            }
        }

        /// <summary>
        /// Inscreve o paciente logado em um evento
        /// </summary>
        /// <param name="idConsulta">ID do evento que o Paciente irá se inscrever</param>
        /// <returns>Um status code 201 - Created</returns>
        /*[Authorize(Roles = "1")]
        [HttpPost("inscricao/{idConsulta}")]
        public IActionResult Join(int idConsulta)
        {
            try
            {
                consulta inscricao = new consulta()
                {
                    // Armazena na propriedade IdUsuario da presenca recebida o ID do usuário logado
                    idPaciente = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value),
                    // Armazena na propriedade IdEvento o ID do evento recebido pela URL
                    idConsulta = idConsulta,
                    // Define a situação da presença como "Não confirmada"
                    idSituacao = 1
                };

                // Faz a chamada para o método
                _consultaRepository.Inscrever(inscricao);

                // Retora a resposta da requisição 201 - Created
                return StatusCode(201);
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(new
                {
                    mensagem = "Não é possível se inscrever se o usuário não estiver logado!",
                    error
                });
            }
        }*/

        /// <summary>
        /// Inscreve 
        /// </summary>
        /// <param name="idConsultaa"></param>
        /// <param name="crmMedico"></param>
        /// <param name="cpfPaciente"></param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpPost("inscricao/{idConsultaa}")]
        public IActionResult Join(int idConsultaa, string crmMedico, string cpfPaciente)
        {
            try
            {
                //Busca o médico pelo nome informado
                medico medicoBuscado = _consultaRepository.BuscarPorNome(crmMedico);

                //Busca o paciente pelo RG informado
                paciente pacienteBuscado = _consultaRepository.BuscarPorRg(cpfPaciente);

                consulta inscricao = new consulta()
                {
                    //Armazena no idCOnsulta o ID da consulta recebido na url
                    idConsulta = idConsultaa,

                    //Armazena o ID do médicoBuscado atrávez do método BuscarPorNome
                    idMedico = medicoBuscado.idMedico,

                    //Armazena o ID do pacienteBuscado atravéz do método BuscarPorRg
                    idPaciente = pacienteBuscado.idPaciente,

                    //Define a situação como "agendada"
                    idSituacao = Convert.ToInt32(1)
                };

                //Chama o método
                _consultaRepository.Inscrever(inscricao);

                //Retorna o status code
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                //Retorna um status code 400 - BadRequest com a exception
                return BadRequest(new
                {
                    mensagem = "Não é possível mostrar as consultas se o usuário não estiver logado!",
                    ex
                });
            }
        }

        /// <summary>
        /// Atualiza a situação de uma consulta
        /// </summary>
        /// <param name="id">ID da situação que será atualizada</param>
        /// <param name="status">Nova situação da consulta</param>
        /// <returns>Um status code 204 - NoContent</returns>
        [Authorize(Roles = "2")]
        [HttpPatch("{id}")]
        public IActionResult UpdateSituation(int id, consulta status)
        {
            try
            {
                _consultaRepository.AprovarRecusar(id, status.idSituacao.ToString());

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                //Retorna um status code 400 - BadRequest com a exception
                return BadRequest(ex);
            }
        }
    }
}
