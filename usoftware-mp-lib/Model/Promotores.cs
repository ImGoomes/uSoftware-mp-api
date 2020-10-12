using RepositoryHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using RepositoryHelpers;


namespace usoftware_mp_lib.Model
{
    public class Promotorias : Base
    {
        public string Nome { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public int FaixaAtendimentoID { get; set; }
        public int AreaAtuacaoID { get; set; }
        [IdentityIgnore]
        public string Area { get; set; }
        [IdentityIgnore]
        public string HorarioInicio { get; set; }
        [IdentityIgnore]
        public string HorarioFim { get; set; }
        [IdentityIgnore]
        public List<Opnioes> Opinioes { get; set; }
    }
}
