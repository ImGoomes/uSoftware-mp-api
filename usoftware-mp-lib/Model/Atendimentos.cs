using RepositoryHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using RepositoryHelpers;


namespace usoftware_mp_lib.Model
{
    public class Atendimentos : Base
    {
        public DateTime DataAgendamento { get; set; }
        public int CidadaoID { get; set; }
        public int PromotoriaID { get; set; }
        public int PromotorID { get; set; }
        public int AreaAtuacaoId { get; set; }
        public string Protocolo { get; set; }
        public string Status { get; set; }
        public string Etapa { get; set; }
        public string Descricao { get; set; }
        [IdentityIgnore]
        public string CidadaoNome { get; set; }
        [IdentityIgnore]
        public string CidadaoCpf { get; set; }
        [IdentityIgnore]
        public string CidadaoRg { get; set; }
        [IdentityIgnore]
        public string CidadaoCelular { get; set; }
        [IdentityIgnore]
        public string PromotorNome { get; set; }
        [IdentityIgnore]
        public string PromotoriaNome { get; set; }
        [IdentityIgnore]
        public string PromotoriaRua { get; set; }
        [IdentityIgnore]
        public string PromotoriaNumero { get; set; }
        [IdentityIgnore]
        public string PromotoriaBairro { get; set; }
        [IdentityIgnore]
        public string PromotoriaCidade { get; set; }
        [IdentityIgnore]
        public string AreaAtuacaoDesc { get; set; }
        [IdentityIgnore]
        public List<Situacao> situacoes { get; set; }
    }
}
