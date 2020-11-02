using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using usoftware_mp_lib.Model;

namespace usoftware_mp_lib.Repository
{
    public class SituacaoRepository : BaseRepository<Situacao>
    {
        public SituacaoRepository(IConfiguration configuration) : base(configuration) { }

        public void Insert(Situacao item)
        {
            this.Repository.Insert(item, false);
        }

        public IEnumerable<Situacao> SelectAll()
        {
            return this.Repository.Get();
        }

        public Situacao SelectByID(int id)
        {
            return this.Repository.GetById(id);
        }

        public void Update(Situacao item)
        {
            this.Repository.Update(item);
        }

        public void Delete(int id)
        {
            this.Repository.Delete(id);
        }

        public IEnumerable<Situacao> SelectByAtendimento(int atendimentoId)
        {
            var customQuery = " SELECT " +
                            "   ID, " +
                            "   Descricao, " +
                            "   AtendimentoID " +
                            " FROM Situacao (NOLOCK) " +
                            " WHERE AtendimentoID = @ID ";

            var parameters = new Dictionary<string, object> { { "ID", atendimentoId } };
            var result = Repository.Get(customQuery, parameters);

            return result;
        }

        public int UpdateByAtendimento(Situacao item)
        {
            var customQuery = "UPDATE Situacao " +
                              "     SET " +
                              "     Descricao = @Descricao " +
                              " WHERE ID = @ID ";

            var parameters = new Dictionary<string, object>();
            parameters.Add("ID", item.ID);
            parameters.Add("Descricao", item.Descricao);
            return Repository.ExecuteQuery(customQuery, parameters);
        }
    }
}

