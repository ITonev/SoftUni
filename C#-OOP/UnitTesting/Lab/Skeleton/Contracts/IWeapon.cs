using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton.Contracts
{
    public interface IWeapon
    {
        int AttackPoints { get; }

        int DurabilityPoints { get; }

        void Attack(ITarget target);
    }
}
