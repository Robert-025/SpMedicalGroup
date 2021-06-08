using senai_spMedicalGroup_webApiDB.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spMedicalGroup_webApiDB.Interfaces
{
    interface ISituacaoRepository
    {
        /// <summary>
        /// Lista todas as situações
        /// </summary>
        /// <returns>Uma lista com as situações</returns>
        List<situacao> Listar();

        /// <summary>
        /// Busca uma situação pelo seu id
        /// </summary>
        /// <param name="id">ID da situação que será buscada</param>
        /// <returns>A situação buscada</returns>
        situacao BuscarPorId(int id);

        /// <summary>
        /// Cadastra uma nova situação
        /// </summary>
        /// <param name="novaSituacao">Objeto com as informações a serem cadastradas</param>
        void Cadastrar(situacao novaSituacao);

        /// <summary>
        /// Atualiza uma situação existente
        /// </summary>
        /// <param name="id">ID da situação que será atualizada</param>
        /// <param name="situacaoAtualizada">Objeto com as informações que serão atualizadas</param>
        void Atualizar(int id, situacao situacaoAtualizada);

        /// <summary>
        /// Deleta uma situação existente
        /// </summary>
        /// <param name="id">ID da situação que será deletada</param>
        void Deletar(int id);
    }
}
