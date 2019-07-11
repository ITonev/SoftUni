using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Interfaces
{
    public interface ISpecialisedSoldier : IPrivate
    {
        string Corp { get; }
    }
}
