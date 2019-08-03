using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton.Contracts
{
    public interface ITarget
    {
        int Health { get; }

        int GiveExperience();

        void TakeAttack(int attackPoints);

        bool IsDead();

    }
}
