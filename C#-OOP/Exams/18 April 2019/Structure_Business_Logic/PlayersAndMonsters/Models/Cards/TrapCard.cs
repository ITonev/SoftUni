using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Cards
{
    public class TrapCard : Card
    {
        private const int DAMAGE_POINTS = 120;
        private const int HEALTH_POINTS = 5;

        public TrapCard(string name)
            : base(name, DAMAGE_POINTS, HEALTH_POINTS)
        {
        }
    }
}
