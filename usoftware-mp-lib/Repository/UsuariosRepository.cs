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

    }
}

