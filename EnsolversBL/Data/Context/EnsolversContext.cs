using EnsolversBL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnsolversBL.Data
{
    public class EnsolversContext : DbContext
    {
        public EnsolversContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
