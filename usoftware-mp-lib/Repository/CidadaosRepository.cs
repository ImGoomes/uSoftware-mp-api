using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using usoftware_mp_lib.Model;

namespace usoftware_mp_lib.Repository
{
    public class CidadaosRepository : BaseRepository<Cidadaos>
    {
        public CidadaosRepository(IConfiguration configuration) : base(configuration) { }

        public void Insert(Cidadaos item)
        {
            this.Repository.Insert(item, false);
        }

        public IEnumerable<Cidadaos> SelectAll()
        {
            return this.Repository.Get();
        }

        public Cidadaos SelectByID(int id)
        {
            return this.Repository.GetById(id);
        }

        public void Update(Cidadaos item)
        {
            this.Repository.Update(item);
        }

        public void Delete(int id)
        {
            this.Repository.Delete(id);
        }
    }
}

