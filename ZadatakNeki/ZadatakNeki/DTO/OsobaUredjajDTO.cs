using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZadatakNeki.DTO
{
    public class OsobaUredjajDTO
    {
        public DateTime PocetakKoriscenja { get; set; }
        public DateTime? KrajKoriscenja { get; set; }
        public OsobaDTO Osoba { get; set; }
        public UredjajDTO Uredjaj { get; set; }
    }
}
