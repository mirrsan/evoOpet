using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZadatakNeki.Models
{
    public class Uredjaj
    {
        public long Id { get; set; }
        public string Naziv { get; set; }

    }
}
