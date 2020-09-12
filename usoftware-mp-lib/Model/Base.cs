using RepositoryHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace usoftware_mp_lib.Model
{
    public class Base
    {
        [PrimaryKey]
        [IdentityIgnore]
        public int ID { get; set; }
        [IdentityIgnore]
        public DateTime CriadoEm { get; set; }
        [DapperIgnore]
        public DateTime RemovidoEm { get; set; }
    }
}
