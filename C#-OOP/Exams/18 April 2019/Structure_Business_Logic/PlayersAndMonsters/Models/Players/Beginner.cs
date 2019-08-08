using System;
using System.Collections.Generic;
using System.Text;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Models.Players
{
    public class Beginner : Player
    {
        private const int HEALTH = 50;

        public Beginner(string username) 
            : base(username, HEALTH)
        {
        }
    }
}
