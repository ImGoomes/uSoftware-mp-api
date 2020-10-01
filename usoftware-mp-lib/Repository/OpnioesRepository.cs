using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using usoftware_mp_lib.Model;

namespace usoftware_mp_lib.Repository
{
    public class OpnioesRepository : BaseRepository<Opnioes>
    {
        public OpnioesRepository(IConfiguration configuration) : base(configuration) { }

        public void Insert(Opnioes item)
        {
            this.Repository.Insert(item, false);
        }

        public IEnumerable<Opnioes> SelectAll()
        {
            return this.Repository.Get();
        }

        public Opnioes SelectByID(int id)
        {
            return this.Repository.GetById(id);
        }

        public void Update(Opnioes item)
        {
            this.Repository.Update(item);
        }

        public void Delete(int id)
        {
            this.Repository.Delete(id);
        }

        public IEnumerable<Opnioes> SelectByPromotoriaID(int promotoriaID)
        {
            var customQuery = "SELECT " +
                              "     * " +
                              " FROM Opnioes O (NOLOCK)" +
                              " WHERE O.PromotoriaID = @PromotoriaID";

            var parameters = new Dictionary<string, object>();
            parameters.Add("PromotoriaID", promotoriaID);
            var result = Repository.Get(customQuery, parameters);

            return result;
        }
    }
}

