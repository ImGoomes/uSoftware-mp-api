using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using usoftware_mp_lib.Model;

namespace usoftware_mp_lib.Repository
{
    public class PromotoriasRepository : BaseRepository<Promotorias>
    {
        public PromotoriasRepository(IConfiguration configuration) : base(configuration) { }

        public void Insert(Promotorias item)
        {
            this.Repository.Insert(item, false);
        }

        public IEnumerable<Promotorias> SelectAll()
        {
            return this.Repository.Get();
        }

        public Promotorias SelectByID(int id)
        {
            var customQuery = " SELECT " +
                             "   P.ID, " +
                             "   P.Nome, " +
                             "   P.Rua, " +
                             "   P.Numero, " +
                             "   P.Cidade, " +
                             "   P.Bairro, " +
                             "   P.CriadoEm, " +
                             "   P.FaixaAtendimentoID, " +
                             "   P.AreaAtuacaoID, " +
                             "   F.HorarioInicio, " +
                             "   F.HorarioFim, " +
                             "   A.Descricao Area, " +
                             "   P.CriadoEm " +
                             " FROM Promotorias P (NOLOCK) " +
                             "   INNER JOIN FaixasAtendimento F ON F.ID = P.FaixaAtendimentoID " +
                             "   INNER JOIN AreasAtuacoes A ON A.ID = P.AreaAtuacaoID " +
                             " WHERE P.ID = @ID ";

            var parameters = new Dictionary<string, object> { { "ID", id } };
            var result = Repository.Get(customQuery, parameters).SingleOrDefault();

            return result;
        }

        public void Update(Promotorias item)
        {
            this.Repository.Update(item);
        }

        public void Delete(int id)
        {
            this.Repository.Delete(id);
        }
    }
}

