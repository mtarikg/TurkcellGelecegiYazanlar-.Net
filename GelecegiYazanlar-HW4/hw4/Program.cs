using hw4.Data;
using hw4.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace hw4
{
    class Program
    {
        static void Main(string[] args)
        {
            NbaDbContext nbaDbContext = new NbaDbContext();
            nbaDbContext.Database.EnsureCreated();

            var allContext = nbaDbContext.Conferences.Include(c => c.Teams).ThenInclude(t => t.Players).ThenInclude(p => p.Position)
                                                     .Include(c => c.Teams).ThenInclude(t => t.Stats).ThenInclude(ts => ts.Stats)
                                                     .Include(c => c.Teams).ThenInclude(t => t.Players).ThenInclude(ps => ps.Stats).ThenInclude(s => s.Stats).ToList();

            var allData = allContext.Select(c => new
            {
                ConferenceInfo = c.Name,
                TeamInfo = c.Teams[0].Name + " " + c.Teams[0].CurrentOwner + " " + c.Teams[0].HeadCoach,
                TeamStatsInfo = c.Teams[0].Stats.ToList()[3].Stats.Name + " " + c.Teams[0].Stats.ToList()[3].Value,
                PlayerInfo = c.Teams[0].Players[0].FirstName + " " + c.Teams[0].Players[0].LastName + " " + c.Teams[0].Players[0].Age,
                PositionInfo = c.Teams[0].Players[0].Position.Name,
                PlayerStatsInfo = c.Teams[0].Players[0].Stats.ToList()[0].Stats.Name + " " + c.Teams[0].Players[0].Stats.ToList()[0].Value
            });

            var allList = allData.ToList();

            allList.ForEach(x =>
            {
                Console.WriteLine(x.ConferenceInfo);
                Console.WriteLine(x.TeamInfo);
                Console.WriteLine(x.TeamStatsInfo);
                Console.WriteLine(x.PlayerInfo + " " + x.PositionInfo);
                Console.WriteLine(x.PlayerStatsInfo);
            });

            Player newPlayer = new Player { FirstName = "Jimmy", LastName = "Butler", Country = "USA", Age = "32 years", DateOfBirth = "September 14, 1989", TeamID = 1, PositionID = 1 };
            nbaDbContext.Players.Add(newPlayer);
            nbaDbContext.SaveChanges();

            nbaDbContext.Players.RemoveRange(nbaDbContext.Players.Where(p => (p.FirstName.Equals("Jimmy")) && (p.LastName.Equals("Butler"))));
            nbaDbContext.SaveChanges();

            var player = nbaDbContext.Players.FirstOrDefault(x => x.ID == 1);
            if (player != null)
            {
                player.FirstName = "Ömer Faruk";
                nbaDbContext.SaveChanges();
            }
        }
    }
}
