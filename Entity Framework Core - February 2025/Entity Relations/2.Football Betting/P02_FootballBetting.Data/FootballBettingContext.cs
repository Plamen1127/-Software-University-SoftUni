﻿using Microsoft.EntityFrameworkCore;
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
        public FootballBettingContext()
        {

        }

        public FootballBettingContext(DbContextOptions options)
            : base(options)
        {

        }

        private const string ConnectionString = "Server=localhost\\SQLEXPRESS06;Database=StudentSystem;Integrated Security=True;";

        public DbSet<Country> Countries { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Town> Towns { get; set; } = null!;
        public DbSet<Position> Positions { get; set; } = null!;
        public DbSet<Color> Colors { get; set; } = null!;
        public DbSet<Team> Teams { get; set; } = null!;
        public DbSet<Bet> Bets { get; set; } = null!;
        public DbSet<Player> Players { get; set; } = null!;
        public DbSet<PlayerStatistic> PlayersStatistics { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PlayerStatistic>(entity =>
            {
                entity.HasKey(ps => new { ps.GameId, ps.PlayerId });
            });
            modelBuilder.Entity<Team>(entity =>
            {
                entity
                .HasOne(t => t.PrimaryKitColor)
                .WithMany(c => c.PrimaryKitTeams)
                .HasForeignKey(t => t.PrimaryKitColorId)
                .OnDelete(DeleteBehavior.NoAction);

                entity
                .HasOne(t => t.SecondaryKitColor)
                .WithMany(c => c.SecondaryKitTeams)
                .HasForeignKey(t => t.SecondaryKitColorId)
                .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity
                .HasOne(g => g.HomeTeam)
                .WithMany(t => t.HomeGames)
                .HasForeignKey(g => g.HomeTeamId)
                .OnDelete(DeleteBehavior.NoAction);

                entity
                .HasOne(g => g.AwayTeam)
                .WithMany(t => t.AwayGames)
                .HasForeignKey(g => g.AwayTeamId)
                .OnDelete(DeleteBehavior.NoAction);

            });
        }

    }
}

