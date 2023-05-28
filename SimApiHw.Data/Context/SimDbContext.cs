using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SimApiHw.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimApiHw.Data.Context
{
    public class SimDbContext:DbContext
    {
        public SimDbContext(DbContextOptions<SimDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
