using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularMonthlyProject.Models
{
    public class DbContextAng: DbContext
    {
        public DbContextAng(DbContextOptions<DbContextAng> con) : base(con)
        {

        }
        public DbSet<Fruit> fruits { get; set; }
        public DbSet<Vegetable> vegetables { get; set; }
        public DbSet<Season> seasons { get; set; }
        public DbSet<FruitSupplier> fruitSuppliers { get; set; }
        public object Configuration { get; internal set; }
    }
}
