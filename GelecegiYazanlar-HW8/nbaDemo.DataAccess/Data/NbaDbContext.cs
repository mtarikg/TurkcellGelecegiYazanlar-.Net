using nbaDemo.Entities;
using Microsoft.EntityFrameworkCore;

namespace nbaDemo.DataAccess.Data
{
    public class NbaDbContext : DbContext
    {
        public NbaDbContext(DbContextOptions<NbaDbContext> options) : base(options) { }

        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Conference> Conferences { get; set; }
        public DbSet<Division> Divisions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

            modelBuilder.Entity<Conference>().HasData(
                new Conference
                {
                    ID = 1,
                    Name = "Eastern Conference",
                    Logo = "https://seeklogo.com/images/N/nba-eastern-conference-logo-0B7E499625-seeklogo.com.png"
                },
                new Conference
                {
                    ID = 2,
                    Name = "Western Conference",
                    Logo = "https://seeklogo.com/images/N/nba-western-conference-logo-CD123BABD3-seeklogo.com.png"
                }
                );

            modelBuilder.Entity<Division>().HasData(
                new Division
                {
                    ID = 1,
                    Name = "Southeast Division"
                },
                new Division
                {
                    ID = 2,
                    Name = "Atlantic Division"
                },
                new Division
                {
                    ID = 3,
                    Name = "Northwest Division"
                },
                new Division
                {
                    ID = 4,
                    Name = "Central Division"
                },
                new Division
                {
                    ID = 5,
                    Name = "Southwest Division"
                },
                new Division
                {
                    ID = 6,
                    Name = "Pacific Division"
                }
                );

            modelBuilder.Entity<Team>().HasData(
                new Team
                {
                    ID = 1,
                    Name = "Miami Heat",
                    Logo = "https://cdn.nba.com/logos/nba/1610612748/global/L/logo.svg",
                    FoundationYear = "1988",
                    CurrentOwner = "Micky Arison",
                    HeadCoach = "Erik Spoelstra",
                    Arena = "FTX Arena",
                    ConferenceID = 1,
                    DivisionID = 1,
                },
                new Team
                {
                    ID = 2,
                    Name = "Toronto Raptors",
                    Logo = "https://cdn.nba.com/logos/nba/1610612761/global/L/logo.svg",
                    FoundationYear = "1995",
                    CurrentOwner = "Maple Leaf Sports and Entertainment",
                    HeadCoach = "Nick Nurse",
                    Arena = "Scotiabank Arena",
                    ConferenceID = 1,
                    DivisionID = 2,
                },
                new Team
                {
                    ID = 3,
                    Name = "Utah Jazz",
                    Logo = "https://cdn.nba.com/logos/nba/1610612762/global/L/logo.svg",
                    FoundationYear = "1974",
                    CurrentOwner = "Ryan Smith",
                    HeadCoach = "Quin Snyder",
                    Arena = "Vivint Arena",
                    ConferenceID = 2,
                    DivisionID = 3,
                }
                );

            modelBuilder.Entity<Position>().HasData(
                new Position
                {
                    ID = 1,
                    Name = "Center"
                },
                new Position
                {
                    ID = 2,
                    Name = "Forward"
                },
                new Position
                {
                    ID = 3,
                    Name = "Guard"
                }, new Position
                {
                    ID = 4,
                    Name = "Center-Forward"
                }, new Position
                {
                    ID = 5,
                    Name = "Guard-Forward"
                }
                );

            modelBuilder.Entity<Player>().HasData(
                new Player
                {
                    ID = 1,
                    FullName = "Bam Adebayo",
                    ProfileImage = "https://cdn.nba.com/headshots/nba/latest/1040x760/1628389.png",
                    Age = "24 years",
                    Country = "USA",
                    LastAttended = "Kentucky",
                    DateOfBirth = "July 18, 1997",
                    DraftInfo = "2017 R1 Pick 14",
                    Experience = "4 years",
                    Height = "6 ft 9 in | (2.06m)",
                    Weight = "255lb | 116kg",
                    JerseyNumber = "#13",
                    PositionID = 4,
                    TeamID = 1
                },
                new Player
                {
                    ID = 2,
                    FullName = "Precious Achiuwa",
                    ProfileImage = "https://cdn.nba.com/headshots/nba/latest/1040x760/1630173.png",
                    Age = "22 years",
                    Country = "Nigeria",
                    LastAttended = "Memphis",
                    DateOfBirth = "September 19, 1999",
                    DraftInfo = "2020 R1 Pick 20",
                    Experience = "1 year",
                    Height = "6 ft 8 in | (2.03m)",
                    Weight = "225lb | 102kg",
                    JerseyNumber = "#13",
                    PositionID = 2,
                    TeamID = 2
                },
                new Player
                {
                    ID = 3,
                    FullName = "Rudy Gobert",
                    ProfileImage = "https://cdn.nba.com/headshots/nba/latest/1040x760/203497.png",
                    Age = "29 years",
                    Country = "France",
                    LastAttended = "Cholet",
                    DateOfBirth = "June 26, 1992",
                    DraftInfo = "2013 R1 Pick 27",
                    Experience = "8 years",
                    Height = "7 ft 1 in | (2.16m)",
                    Weight = "258lb | 117kg",
                    JerseyNumber = "#27",
                    PositionID = 1,
                    TeamID = 3
                }
                );
        }
    }
}