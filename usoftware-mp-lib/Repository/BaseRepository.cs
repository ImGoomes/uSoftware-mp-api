using Microsoft.Extensions.Configuration;
using RepositoryHelpers.DataBase;
using RepositoryHelpers.DataBaseRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace usoftware_mp_lib.Repository
{

        public class BaseRepository<T>
        {
            protected readonly CustomRepository<T> Repository;
            private readonly IConfiguration configuration;

            public BaseRepository(IConfiguration config)
            {
                configuration = config;

                var connection = new Connection()
                {
                    Database = RepositoryHelpers.Utils.DataBaseType.SqlServer,
                    ConnectionString = configuration.GetSection("ConnectionStrings:Conexao").Value
                };

                Repository = new CustomRepository<T>(connection);
            }

        }

}
