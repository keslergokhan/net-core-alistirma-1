using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCOGRENME.Entities.Concrete
{
    public class DbMvcOgrenmeContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=DESKTOP-EFM1DKV\SQLEXPRESS;Database=TeknikServis;Trusted_Connection=True;User Id=gkhnk;Password=;");
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-EFM1DKV\SQLEXPRESS;Database=MVCOGRENME;Trusted_Connection=True;User Id=gkhnk;Password=;");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
