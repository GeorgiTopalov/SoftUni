using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basketball
{
    public class Team
    {
        string name;
        int openPositions;
        char group;
        List<Player> players = new List<Player>();
        public Team(string name, int openPositions, char group)
        {
            this.name = name;
            this.openPositions = openPositions;
            this.group = group;
            this.players = new List<Player>();
        }

        public string Name { get { return this.name; } set { this.name = value; } }
        public int OpenPositions { get { return this.openPositions; } set { this.openPositions = value; } }
        public char Group { get { return this.group; } set { this.group = value; } }
        public List<Player> Players { get { return this.players; } set { this.players = value; } }

        public int Count { get { return this.players.Count; } }

        public string AddPlayer(Player player)
        {
            if (String.IsNullOrEmpty(player.Name) || String.IsNullOrEmpty(player.Position))
            {
                return "Invalid player's information.";
            }
            else if (this.OpenPositions == 0)
            {
                return "There are no more open positions.";
            }
            else if (player.Rating < 80)
            {
                return "Invalid player's rating.";
            }
            else
            {
                this.OpenPositions--;
                Players.Add(player);
                return $"Successfully added {player.Name} to the team. Remaining open positions: {this.OpenPositions}.";
            }
        }
        public bool RemovePlayer(string name)
        {
            Player player = Players.FirstOrDefault(x => x.Name == name);
            if (player != default)
            {
                this.Players.Remove(player);
                this.OpenPositions++;
                return true;
            }

            return false;
        }

        public int RemovePlayerByPosition(string position)
        {

            List<Player> list = this.Players.Where(x => x.Position != position).ToList();
            int removedPlayers = this.Count - list.Count;
            this.OpenPositions += this.Count - list.Count;
            this.Players = list;

            return removedPlayers;

        }

        public Player RetirePlayer(string name)
        {
            Player player = Players.FirstOrDefault(x => x.Name == name);

            if (player == default)
            {
                return null;
            }

            player.Retired = true;
            return player;
        }

        public List<Player> AwardPlayers(int games) => this.Players.Where(x => x.Games >= games).ToList();

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Active players competing for Team {this.Name} from Group {this.Group}:");

            foreach (Player player in this.Players.Where(x => x.Retired == false))
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
