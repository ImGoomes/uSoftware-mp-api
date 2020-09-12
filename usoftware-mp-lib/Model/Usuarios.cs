using RepositoryHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using RepositoryHelpers;


namespace usoftware_mp_lib.Model
{
    public class Usuarios : Base
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }

    }
}
