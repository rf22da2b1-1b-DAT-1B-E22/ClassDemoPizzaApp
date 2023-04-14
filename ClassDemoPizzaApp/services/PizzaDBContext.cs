using Microsoft.EntityFrameworkCore;
using PizzaLib.model;

namespace ClassDemoPizzaApp.services
{
    public class PizzaDBContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(Secret.GetConnectionString);
        }

        public virtual DbSet<Pizza> Pizza { get; set; }
    }
}
