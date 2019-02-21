using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Remotion.Linq.Clauses;
using ZadatakNeki.DTO;
using ZadatakNeki.Models;

namespace ZadatakNeki.Controllers
{
    [Route("api/[controller]/[action]")]
    public class KancelarijaController : BaseController<Kancelarija, KancelarijaDTO>
    {
        private readonly ToDoContext _context;
        private readonly IMapper _mapper;

        public KancelarijaController(ToDoContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // akcija koja vraca sve kancelarije
        [HttpGet]
        public IActionResult SveKancelarije()
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
        public IActionResult Upisivanje(KancelarijaDTO kancelarijaNova)
        {
            return base.Upisivanje(kancelarijaNova);
        }

        // akcija koja menja postojeci entitet koji ima dati ID
        [HttpPut("{id}:int")]
        public IActionResult IzmenaPodataka(long id, KancelarijaDTO kancelarija)
        {
            return base.Izmena(id, kancelarija);
        }

        // akcija koja brise entitet koji ima dati ID
        [HttpDelete("{id}")]
        public IActionResult Brisanje(long id)
        {
            Kancelarija kancelarija = _context.Kancelarije.Find(id);

            if (kancelarija == null)
            {
                return NotFound();
            }

            if (kancelarija.Opis.Equals("kantina"))
            {
                return BadRequest("Necu obrisat kantinu.");
            }

            List<Osoba> beziIzKancelarije = (from nn in _context.Osobe
                where nn.Kancelarija == kancelarija
                select nn).ToList();

            for (int i = 0; i < beziIzKancelarije.Count(); i++)
            {
                Osoba osoba = beziIzKancelarije[i];

                osoba.Kancelarija = new Kancelarija() {Opis = "kantina"};

                var mozdaIma = (from nn in _context.Kancelarije
                    where nn.Opis == osoba.Kancelarija.Opis
                    select nn).FirstOrDefault();

                if (mozdaIma != null)
                {
                    osoba.Kancelarija = mozdaIma;
                }

                _context.SaveChanges();
            }
            
            _context.Kancelarije.Remove(kancelarija);
            _context.SaveChanges();

            return Ok("Kancelarija je izbrisana iz baze podataka.");
        }

        // akcija koja pretrazuje entitet po imenu osobe
        [HttpGet("{opis}")]
        public IActionResult PretragaPoImenu(string opis)
        {
            var kancelarija = from n in _context.Kancelarije where n.Opis == opis select new {Naziv = n.Opis};
            if (kancelarija == null)
            {
                return NotFound();
            }
            return Ok(kancelarija.ToList());
        }
    }
}