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
            return this.Repository.GetById(id);
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

