using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using usoftware_mp_lib.Model;

namespace usoftware_mp_lib.Repository
{
    public class AtendimentosRepository : BaseRepository<Atendimentos>
    {
        public AtendimentosRepository(IConfiguration configuration) : base(configuration) { }

        public void Insert(Atendimentos item)
        {
            this.Repository.Insert(item, false);
        }

        public IEnumerable<Atendimentos> SelectAll()
        {
            return this.Repository.Get();
        }

        public Atendimentos SelectByID(int id)
        {
            return this.Repository.GetById(id);
        }

        public void Update(Atendimentos item)
        {
            this.Repository.Update(item);
        }

        public void Delete(int id)
        {
            this.Repository.Delete(id);
        }

        public IEnumerable<Atendimentos> SelectList()
        {
            var customQuery = " SELECT " +
                             "   A.ID, " +
                             "   A.DataAgendamento, " +
                             "   A.CidadaoID, " +
                             "   A.PromotoriaID, " +
                             "   A.PromotorID, " +
                             "   A.AreaAtuacaoID, " +
                             "   A.Protocolo, " +
                             "   A.Status, " +
                             "   A.Etapa, " +
                             "   A.Descricao, " +
                             "   A.CriadoEm, " +
                             "   C.Nome CidadaoNome, " +
                             "   C.Cpf CidadaoCpf, " +
                             "   C.Rg CidadaoRg, " +
                             "   C.Celular CidadaoCelular, " +
                             "   PR.Nome PromotorNome, " +
                             "   PA.Nome PromotoriaNome, " +
                             "   PA.Rua PromotoriaRua, " +
                             "   PA.Numero PromotoriaNumero, " +
                             "   PA.Bairro PromotoriaBairro, " +
                             "   PA.Cidade PromotoriaCidade, " +
                             "   AA.Descricao AreaAtuacaoDesc " +
                             " FROM Atendimentos A (NOLOCK) " +
                             "   INNER JOIN Cidadaos C ON C.ID = A.CidadaoID " +
                             "   INNER JOIN Promotorias PA ON PA.ID = A.PromotoriaID " +
                             "   LEFT JOIN Promotores PR ON PR.ID = A.PromotorID " +
                             "   INNER JOIN AreasAtuacoes AA ON AA.ID = A.AreaAtuacaoID ";

            var parameters = new Dictionary<string, object>();
            var result = Repository.Get(customQuery, parameters);

            return result;
        }

        public Atendimentos SelectDetail(int id)
        {
            var customQuery = " SELECT " +
                             "   A.ID, " +
                             "   A.DataAgendamento, " +
                             "   A.CidadaoID, " +
                             "   A.PromotoriaID, " +
                             "   A.PromotorID, " +
                             "   A.AreaAtuacaoID, " +
                             "   A.Protocolo, " +
                             "   A.Status, " +
                             "   A.Etapa, " +
                             "   A.Descricao, " +
                             "   A.CriadoEm, " +
                             "   C.Nome CidadaoNome, " +
                             "   C.Cpf CidadaoCpf, " +
                             "   C.Rg CidadaoRg, " +
                             "   C.Celular CidadaoCelular, " +
                             "   PR.Nome PromotorNome, " +
                             "   PA.Nome PromotoriaNome, " +
                             "   PA.Rua PromotoriaRua, " +
                             "   PA.Numero PromotoriaNumero, " +
                             "   PA.Bairro PromotoriaBairro, " +
                             "   PA.Cidade PromotoriaCidade, " +
                             "   AA.Descricao AreaAtuacaoDesc " +
                             " FROM Atendimentos A (NOLOCK) " +
                             "   INNER JOIN Cidadaos C ON C.ID = A.CidadaoID " +
                             "   INNER JOIN Promotorias PA ON PA.ID = A.PromotoriaID " +
                             "   LEFT JOIN Promotores PR ON PR.ID = A.PromotorID " +
                             "   INNER JOIN AreasAtuacoes AA ON AA.ID = A.AreaAtuacaoID " +
                             " WHERE A.ID = @ID ";

            var parameters = new Dictionary<string, object> { { "ID", id } };
            var result = Repository.Get(customQuery, parameters).SingleOrDefault();

            return result;
        }
    }
}

