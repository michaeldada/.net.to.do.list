using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace _2ToList2.Models
{
    public class _2ToList2Context : DbContext
    {
        public virtual DbSet<Item> Items { get; set; }
        protected override void OnConfiguring (DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=2ToList2;integrated security=True");
        }
    }
}
