using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private Dictionary<string, Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new Dictionary<string, Player>();
        }

        private int NumberOfPlayers
        {
            get { return this.players.Count; }
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                this.name = value;
            }
        }

        private double Rating
        {
            get
            {
                if (this.players.Count == 0)
                {
                    return 0;
                }

                return this.players.Average(p => p.Value.SkillLevel);
            }
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player.Name, player);
        }

        public void RemovePlayer(string playerName)
        {
            if (!this.players.ContainsKey(playerName))
            {
                throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
            }

            this.players.Remove(playerName);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Rating:F0}";
        }
    }
}
