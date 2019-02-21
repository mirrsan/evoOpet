using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZadatakNeki.Models;

namespace ZadatakNeki.Controllers
{
    [Route("api/[controller]/[action]")]
    public class BaseController<T, Tdto> : Controller where T : class
                                                      where Tdto : class
    {
        private readonly ToDoContext _context;
        private readonly IMapper _mapper;
        public readonly DbSet<T> _DbSet;
        
        public BaseController(ToDoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _DbSet = _context.Set<T>();
        }

        // akcija koja vraca sve entitete
        protected virtual IActionResult DajSve()
        {
            var svi = _DbSet.ProjectTo<Tdto>(_mapper.ConfigurationProvider);
            return Ok(svi.ToList());
        }

        // akcija koja vraca entitet koji ima dati ID
        protected virtual IActionResult PoId(long id)
        {
            var entitet = _mapper.Map<Tdto>(_DbSet.Find(id));

            if (entitet == null)
            {
                return BadRequest("Nema ti toga odje.");
            }

            return Ok(entitet);
        }

        // akcija koja upisuje entitet u bazu
        protected virtual IActionResult Upisivanje(Tdto koga)
        {
            T entitet = _mapper.Map<T>(koga);

            _DbSet.Add(entitet);
            _context.SaveChanges();

            return Ok("Nije uspelo, ahahah salim se sacuvao sam.");
        }

        // akcija za izmenu podataka entiteta
        protected virtual IActionResult Izmena(long id, Tdto entitetDTO)
        {
            T entitet = _DbSet.Find(id);
            if (entitet == null)
            {
                return BadRequest("Ne mogu naci entitet koji menjas");
            }
            T map = _mapper.Map<Tdto, T>(entitetDTO, entitet);
            var ww = _context.Attach(map).Entity;
            _context.SaveChanges();

            return Ok("Vase izmene su sacuvane!");
        }

        // akcija za brisanje entiteta 
        protected virtual IActionResult Brisanje(long id)
        {
            T entitet = _DbSet.Find(id);
            if (entitet == null)
            {
                return NotFound("Sta ces brisat, njega nako nije ni bilo.");
            }

            _DbSet.Remove(entitet);
            _context.SaveChanges();

            return Ok("Obrisao sam.");
        }
    }
}