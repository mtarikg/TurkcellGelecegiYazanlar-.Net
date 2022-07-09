using nbaDemo.DTOs.Responses;
using System;
using System.Collections.Generic;

namespace nbaDemo.Web.Models
{
    public class FavoritePlayer
    {
        public PlayerListResponse Player { get; set; }
    }

    public class FavoritePlayersCollection
    {
        public List<FavoritePlayer> FavoritePlayers { get; set; } = new List<FavoritePlayer>();

        public bool FindPlayer(int id)
        {
            var playerFound = FavoritePlayers.Find(p => p.Player.ID == id);

            if (playerFound != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddPlayer(FavoritePlayer player)
        {
            var result = FindPlayer(player.Player.ID);

            if (!result)
            {
                FavoritePlayers.Add(player);
            }
            else
            {
                Console.WriteLine("Error for adding team");
            }
        }

        public void Delete(int id) => FavoritePlayers.RemoveAll(fp => fp.Player.ID == id);
    }
}
