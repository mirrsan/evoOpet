using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZadatakNeki.DTO
{
    public class OsobaDTO
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public KancelarijaDTO Kancelarija { get; set; }
    }
}
