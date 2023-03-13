using Golf_Club_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Golf_Club_Management.dbcontext {
    public class AppDbContext:DbContext
        {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite(@"Data Source=DataBase\database.db");

        public DbSet<Golfer> golfers { get; set; }

        public DbSet<TeeTime> teeTimes { get; set; }
    }
}
