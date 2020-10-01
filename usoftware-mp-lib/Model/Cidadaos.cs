using RepositoryHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using RepositoryHelpers;


namespace usoftware_mp_lib.Model
{
    public class Cidadaos : Base
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string RG { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Celular { get; set; }
        public string Endereco { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public int UsuarioID { get; set; }

    }
}
