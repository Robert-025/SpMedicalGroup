using senai_spMedicalGroup_webApiDB.Context;
using senai_spMedicalGroup_webApiDB.Domains;
using senai_spMedicalGroup_webApiDB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spMedicalGroup_webApiDB.Repositories
{
    public class SituacaoRepository : ISituacaoRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        SpMedicalGroupContext ctx = new SpMedicalGroupContext();

        /// <summary>
        /// Atualiza uma situação existente
        /// </summary>
        /// <param name="id">ID da situação que será atualizada</param>
        /// <param name="situacaoAtualizada">Objeto com as informações que serão atualizadas</param>
        public void Atualizar(int id, situacao situacaoAtualizada)
        {
            //Busca uma situação pelo seu id
            situacao situacaoBuscada = BuscarPorId(id);

            //Verifica se a descrição da situação foi informada
            if (situacaoAtualizada != null)
            {
                //Caso tenha sido, atribui o novo valor ao campo
                situacaoBuscada.descricao = situacaoAtualizada.descricao;
            }

            //Atualiza a situação que foi buscada
            ctx.situacoes.Update(situacaoBuscada);

            //Salva as informações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca uma situação pelo seu id
        /// </summary>
        /// <param name="id">ID da situação que será buscada</param>
        /// <returns>A situação buscada</returns>
        public situacao BuscarPorId(int id)
        {
            //Retorna o resultado da busca na lista de situações
            return ctx.situacoes.Find(id);
        }

        /// <summary>
        /// Cadastra uma nova situação
        /// </summary>
        /// <param name="novaSituacao">Objeto com as informações a serem cadastradas</param>
        public void Cadastrar(situacao novaSituacao)
        {
            //Adiciona na lista de situacoes o objeto novaSituacao
            ctx.situacoes.Add(novaSituacao);

            //Salva as informações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta uma situação existente
        /// </summary>
        /// <param name="id">ID da situação que será deletada</param>
        public void Deletar(int id)
        {
            //Remove a especialidade que está sendo buscada
            ctx.situacoes.Remove(BuscarPorId(id));

            //Salva as alterações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todas as situações
        /// </summary>
        /// <returns>Uma lista com as situações</returns>
        public List<situacao> Listar()
        {
            //Retorna a lista de situações
            return ctx.situacoes.ToList();
        }
    }
}
