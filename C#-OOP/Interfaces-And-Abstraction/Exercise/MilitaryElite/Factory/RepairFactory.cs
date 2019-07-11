using MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Factory
{
    public class RepairFactory
    {
        public Repair MakeRepair(string partName, int hoursWorked)
        {
            Repair repair = new Repair(partName, hoursWorked);

            return repair;
        }
    }
}
