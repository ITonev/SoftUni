using MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Factory
{
    public class MissionFactory
    {
        public Mission MakeMission(string codeName, string state)
        {
            Mission mission = new Mission(codeName, state);

            return mission;
        }
    }
}
