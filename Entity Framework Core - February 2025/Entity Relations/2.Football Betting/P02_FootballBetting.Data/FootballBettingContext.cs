using Microsoft.EntityFrameworkCore;
using P02_FootballBetting.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Color = P02_FootballBetting.Models.Color;

namespace P02_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        private const string ConnectionString = "Server=localhost\\SQLEXPRESS06;Database=StudentSystem;Integrated Security=True;";

        public DbSet<Country> Countries { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Town> Towns { get; set; } = null!;
        public DbSet<Position> Positions { get; set; } = null!;
        public DbSet<Color> Colors { get; set; } = null!;
        public DbSet<Team> Teams { get; set; } = null!;

       



        // public StudentSystemContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        // {
        // }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
