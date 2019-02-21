using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZadatakNeki.Models
{
    public class Kancelarija
    {
        public long Id { get; set; }
        public string Opis { get; set; }

        public List<Osoba> Osobe { get; set; }
    }
}
