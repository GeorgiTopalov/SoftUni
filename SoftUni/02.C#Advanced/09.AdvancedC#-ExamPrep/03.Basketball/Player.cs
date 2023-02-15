using System;
using System.Text;

namespace Basketball
{
    public class Player
    {
        string name;
        string position;
        double rating;
        int games;
        bool retired;
        public Player(string name, string position, double rating, int games)
        {
            this.name = name;
            this.position = position;
            this.rating = rating;
            this.games = games;
        }

        public string Name { get { return this.name; } set { this.name = value; } }
        public string Position { get { return this.position; } set { this.position = value; } }
        public double Rating { get { return this.rating; } set { this.rating = value; } }
        public int Games { get { return this.games; } set { this.games = value; } }
        public bool Retired { get { return this.retired; } set { this.retired = value; } }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"-Player: {this.Name}");
            sb.AppendLine($"--Position: {this.Position}");
            sb.AppendLine($"--Rating: {this.Rating}");
            sb.AppendLine($"--Games played: {this.Games}");

            return sb.ToString().TrimEnd();
        }

    }
}
