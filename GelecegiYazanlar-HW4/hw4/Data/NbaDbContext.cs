using hw4.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace hw4.Data
{
    class NbaDbContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Conference> Conferences { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Stats> Stats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = (localdb)\Mssqllocaldb; Database = nbaDemoDb; Integrated Security = yes");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().Property(p => p.FirstName).IsRequired();
            modelBuilder.Entity<Player>().Property(p => p.LastName).IsRequired();
            modelBuilder.Entity<Player>().Property(p => p.Country).IsRequired();
            modelBuilder.Entity<Player>().Property(p => p.Age).IsRequired();
            modelBuilder.Entity<Player>().Property(p => p.DateOfBirth).IsRequired();

            modelBuilder.Entity<Team>().Property(t => t.Name).IsRequired();
            modelBuilder.Entity<Team>().Property(t => t.FoundationYear).IsRequired();
            modelBuilder.Entity<Team>().Property(t => t.CurrentOwner).IsRequired();
            modelBuilder.Entity<Team>().Property(t => t.HeadCoach).IsRequired();
            modelBuilder.Entity<Team>().Property(t => t.Arena).IsRequired();

            modelBuilder.Entity<Conference>().Property(c => c.Name).IsRequired();

            modelBuilder.Entity<Division>().Property(d => d.Name).IsRequired();

            modelBuilder.Entity<Position>().Property(pos => pos.Name).IsRequired();

            modelBuilder.Entity<Stats>().Property(s => s.Name).IsRequired();

            modelBuilder.Entity<Player>().HasOne(player => player.Team)
                .WithMany(team => team.Players)
                .HasForeignKey(p => p.TeamID)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Player>().HasOne(player => player.Position)
                .WithMany(position => position.Players)
                .HasForeignKey(p => p.PositionID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Team>().HasOne(team => team.Conference)
                .WithMany(conference => conference.Teams)
                .HasForeignKey(t => t.ConferenceID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Team>().HasOne(team => team.Division)
                .WithMany(division => division.Teams)
                .HasForeignKey(t => t.DivisionID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PlayersStats>().HasKey(ps => new { ps.PlayerID, ps.StatsID });

            modelBuilder.Entity<Player>().HasMany(p => p.Stats)
                .WithOne(ps => ps.Player)
                .HasForeignKey(x => x.PlayerID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TeamsStats>().HasKey(ts => new { ts.TeamID, ts.StatsID });

            modelBuilder.Entity<Team>().HasMany(t => t.Stats)
                .WithOne(ts => ts.Team)
                .HasForeignKey(x => x.TeamID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Conference>().HasData(new Conference { ID = 1, Name = "Eastern Conference" });

            modelBuilder.Entity<Division>().HasData(new Division { ID = 1, Name = "Southeast" });

            modelBuilder.Entity<Stats>().HasData(new Stats { ID = 1, Name = "PPG" });
            modelBuilder.Entity<Stats>().HasData(new Stats { ID = 2, Name = "RPG" });
            modelBuilder.Entity<Stats>().HasData(new Stats { ID = 3, Name = "APG" });
            modelBuilder.Entity<Stats>().HasData(new Stats { ID = 4, Name = "Team Record" });

            modelBuilder.Entity<Team>().HasData(new Team
            {
                ID = 1,
                Name = "Miami Heat",
                FoundationYear = "1997",
                CurrentOwner = "Micky Arison",
                HeadCoach = "Erik Spoelstra",
                Arena = "American Airlines Arena",
                ConferenceID = 1,
                DivisionID = 1
            });

            modelBuilder.Entity<Position>().HasData(new Position { ID = 1, Name = "Center" });

            modelBuilder.Entity<Player>().HasData(new Player
            {
                ID = 1,
                FirstName = "Ömer",
                LastName = "Yurtseven",
                Country = "Turkey",
                Age = "23 years",
                DateOfBirth = "June 19, 1998",
                LastAttended = "Georgetown",
                Height = "2.11m (6'11\")",
                Weight = "125kg (275lb)",
                JerseyNumber = "#77",
                Experience = "Rookie",
                DraftInfo = "Undrafted",
                PositionID = 1,
                TeamID = 1
            });

            modelBuilder.Entity<PlayersStats>().HasData(new PlayersStats { PlayerID = 1, StatsID = 1, Value = "5.7" });
            modelBuilder.Entity<PlayersStats>().HasData(new PlayersStats { PlayerID = 1, StatsID = 2, Value = "5.4" });
            modelBuilder.Entity<PlayersStats>().HasData(new PlayersStats { PlayerID = 1, StatsID = 3, Value = "0.9" });

            modelBuilder.Entity<TeamsStats>().HasData(new TeamsStats { TeamID = 1, StatsID = 1, Value = "109.5" });
            modelBuilder.Entity<TeamsStats>().HasData(new TeamsStats { TeamID = 1, StatsID = 2, Value = "44.3" });
            modelBuilder.Entity<TeamsStats>().HasData(new TeamsStats { TeamID = 1, StatsID = 3, Value = "25.8" });
            modelBuilder.Entity<TeamsStats>().HasData(new TeamsStats { TeamID = 1, StatsID = 4, Value = "45-23" });
        }
    }
}
