using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using usoftware_mp_lib.Model;

namespace usoftware_mp_lib.Repository
{
    public class UsuariosRepository : BaseRepository<Usuarios>
    {
        public UsuariosRepository(IConfiguration configuration) : base(configuration) { }

        public void Insert(Usuarios item)
        {
            this.Repository.Insert(item, false);
        }

        public IEnumerable<Usuarios> SelectAll()
        {
            return this.Repository.Get();
        }

        public Usuarios SelectByID(int id)
        {
            return this.Repository.GetById(id);
        }

        public void Update(Usuarios item)
        {
            this.Repository.Update(item);
        }

        public void Delete(int id)
        {
            this.Repository.Delete(id);
        }

        public Usuarios LoginUsuario(Usuarios item)
        {
            var customQuery = "SELECT " +
                              "     U.ID, " +
                              "     U.Nome, " +
                              "     U.Login, " +
                              "     U.Senha, " +
                              "     U.Ativo " +
                              " FROM Usuarios U (NOLOCK)" +
                              " WHERE U.Login = @Login" +
                              "     AND U.Senha = @Senha " +
                              "     AND U.Ativo = 1";

            var parameters = new Dictionary<string, object>();
            parameters.Add("Login", item.Login);
            parameters.Add("Senha", item.Senha);
            var result = Repository.Get(customQuery, parameters).SingleOrDefault();

            return result;
        }

        public Usuarios LastUser()
        {
            var customQuery = "SELECT TOP 1 " +
                              "     U.ID, " +
                              "     U.Nome, " +
                              "     U.Login, " +
                              "     U.Senha, " +
                              "     U.Ativo " +
                              " FROM Usuarios U (NOLOCK)" +
                              " ORDER BY 1 DESC";

            var parameters = new Dictionary<string, object>();
            var result = Repository.Get(customQuery, parameters).SingleOrDefault();

            return result;
        }
    }
}

