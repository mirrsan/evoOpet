using JetBrains.Annotations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ZadatakNeki.Models
{
    public class ToDoContext : DbContext
    {

        public ToDoContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Osoba> Osobe { get; set; }
        public DbSet<Uredjaj> Uredjaji { get; set; }
        public DbSet<Kancelarija> Kancelarije { get; set; }
        public DbSet<OsobaUredjaj> OsobaUredjaj { get; set; }
    }
}
