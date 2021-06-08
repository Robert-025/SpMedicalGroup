using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai_spMedicalGroup_webApiDB.Domains;
using senai_spMedicalGroup_webApiDB.Interfaces;
using senai_spMedicalGroup_webApiDB.Repositories;
using senai_spMedicalGroup_webApiDB.ViewModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai_spMedicalGroup_webApiDB.Controllers
{
    /// <summary>
    /// Controller responsavel pelos endpoints ao Login
    /// </summary>
    /// 

    //Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    //Define que a rota de uma requisição será no formato dominio/api/nomeController
    [Route("api/[controller]")]

    //Define que é um controlador de API 
    [ApiController]
    public class LoginController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber os métodos definidos na interface IUsuarioRepository
        /// </summary>
        private IUsuarioRepository _usuarioRepository { get; set; }

        public LoginController()
        {
            //Atribui o _usuarioRepository ao UsuarioRepository para ter referências aos métodos lá montados
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Faz o login de um usuario
        /// </summary>
        /// <param name="login">Objeto com as informações de login</param>
        /// <returns>Um status code 200 - OK com o token</returns>
        [HttpPost]
        public IActionResult Post(LoginViewModel login)
        {
            try
            {
                //Busca o usuário pelo email e senha
                usuario usuarioBuscado = _usuarioRepository.Login(login.email, login.senha);

                //Verifica se o usuarioBuscado foi encontrado
                if (usuarioBuscado == null)
                {
                    //Caso não encpntre, retorna o status code 404 com uma mensagem personalizada
                    return NotFound("E-mail ou senha inválidos!");
                }

                //Caso seja encontrado, continua

                //Define as informações que serão fornecidos no token 
                var claims = new[]
                {
                    //Armazena na claim o email do usuario autenticado
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.email),

                    //Armazena na claim o id do usuario autenticado
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.idUsuario.ToString()),

                    //Armazena na claim o tipo do usuario autenticado
                    new Claim(ClaimTypes.Role, usuarioBuscado.idTipo.ToString())
                };

                //Define a chave de acesso ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("sp-medical-group-autenticacao"));

                //Define as credenciais do token - Header
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //Gera o token
                var token = new JwtSecurityToken(

                    issuer : "spMedicalGroup.webApi",       //Emissor do token
                    audience : "spMedicalGroup.webApi",     //Destinatário do token
                    claims : claims,                        //Dados definidos acima
                    expires : DateTime.Now.AddMinutes(30),  //Tempo de expiração
                    signingCredentials : creds              //Credenciais do token
                    );

                //Retorna Ok com o token
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception ex)
            {
                //Retorna o status code com o código de erro
                return BadRequest(ex);
            }
        }
    }
}
