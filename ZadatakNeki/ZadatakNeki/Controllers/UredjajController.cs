using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using ZadatakNeki.DTO;
using ZadatakNeki.Models;

namespace ZadatakNeki.Controllers
{
    [Route("[controller]/[action]")]
    public class UredjajController : BaseController<Uredjaj, UredjajDTO>
    {
        private readonly ToDoContext _context;
        private readonly IMapper _mapper;

        public UredjajController(ToDoContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // akcija koja vraca sve kancelarije
        [HttpGet]
        public IActionResult Svi()
        {
            return base.DajSve();
        }

        // akcija koja vraca samo entitet koji ima dati ID
        [HttpGet("{id}:int")]
        public IActionResult PoId(long id)
        {
            return base.PoId(id);
        }

        // akcija koja upisuje novi entitet u bazu
        [HttpPost]
        public IActionResult Upisivanje(UredjajDTO uredjajNovi)
        {
            return base.Upisivanje(uredjajNovi);
        }

        // akcija koja menja postojeci entitet koji ima dati ID
        [HttpPut("{id}:int")]
        public IActionResult IzmenaPodataka(long id, UredjajDTO uredjaj)
        {
            return base.Izmena(id, uredjaj);
        }

        // akcija koja brise entitet koji ima dati ID
        [HttpDelete("{id}")]
        public IActionResult Brisanje(long id)
        {
            Uredjaj uredjaj = _context.Uredjaji.Find(id);

            if (uredjaj == null)
            {
                return NotFound();
            }

            var mozda = (from nn in _context.OsobaUredjaj
                where nn.UredjajId == id
                select new { Uredjaj = nn.Uredjaj.Naziv }).FirstOrDefault();

            if (mozda != null)
            {
                return BadRequest("Uredjaj nije izbrisan zato sto je nekada vec bio koriscen.");
            }
            
            _context.Uredjaji.Remove(uredjaj);
            _context.SaveChanges();

            return Ok("Uredjaj je izbrisan iz baze podataka.");
        }

        // akcija koja pretrazuje entitet po imenu osobe
        [HttpGet("{naziv}")]
        public IActionResult PretragaPoImenu(string naziv)
        {
            var uredjaj = from n in _context.Uredjaji where n.Naziv == naziv select new { Naziv = n.Naziv };
            if (uredjaj == null)
            {
                return NotFound();
            }
            return Ok(uredjaj.ToList());
        }

        // akcija koja vraca uredjaje koji se koriste
        [HttpGet]
        public IActionResult PretragaUredjajiKojiSeKoriste()
        {
            var koristeSe = from nn in _context.OsobaUredjaj select new {Uredjaj = nn.Uredjaj.Naziv};

            return Ok(koristeSe.ToList());
        }
        
    }
}
