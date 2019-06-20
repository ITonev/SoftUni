using System;
using System.Collections.Generic;
using System.Text;

namespace FightingArena
{
    public class Weapon
    {
        public int Size { get; set; }

        public int Solidity { get; set; }

        public int Sharpness { get; set; }

        public Weapon(int size, int solidity, int sharpness)
        {
            this.Size = size;
            this.Solidity = solidity;
            this.Sharpness = sharpness;
        }
    }
}
