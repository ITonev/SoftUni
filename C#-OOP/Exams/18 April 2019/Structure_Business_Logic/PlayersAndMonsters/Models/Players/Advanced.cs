using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Players
{
   public class Advanced : Player
    {
        private const int HEALTH = 250;

        public Advanced(string username)
            : base(username, HEALTH)
        {
        }
    }
}
