using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Cards
{
    public class MagicCard : Card
    {
        private const int DAMAGE_POINTS = 5;
        private const int HEALTH_POINTS = 80;

        public MagicCard(string name) 
            : base(name, DAMAGE_POINTS, HEALTH_POINTS)
        {
        }
    }
}
