using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using usoftware_mp_lib.Model;

namespace usoftware_mp_lib.Repository
{
    public class PromotoresRepository : BaseRepository<Promotores>
    {
        public PromotoresRepository(IConfiguration configuration) : base(configuration) { }

        public void Insert(Promotores item)
        {
            this.Repository.Insert(item, false);
        }

        public IEnumerable<Promotores> SelectAll()
        {
            return this.Repository.Get();
        }

        public Promotores SelectByID(int id)
        {
            return this.Repository.GetById(id);
        }

        public void Update(Promotores item)
        {
            this.Repository.Update(item);
        }

        public void Delete(int id)
        {
            this.Repository.Delete(id);
        }
    }
}

