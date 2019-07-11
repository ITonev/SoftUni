using MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Factory
{
    public class LieutenantGeneralFactory
    {
        public LieutenantGeneral MakeLieutenantGeneral(string[] args)
        {
            int id = int.Parse(args[1]);
            string firstName = args[2];
            string lastName = args[3];
            decimal salary = decimal.Parse(args[4]);

            LieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);

            return lieutenantGeneral;
        }
    }
}
