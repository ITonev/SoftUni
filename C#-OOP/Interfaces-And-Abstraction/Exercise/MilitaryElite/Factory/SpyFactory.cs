using MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Factory
{
    public class SpyFactory
    {
        public Spy MakeSpy(string[] args)
        {
            int id = int.Parse(args[1]);
            string firstName = args[2];
            string lastName = args[3];
            int codeNumber = int.Parse(args[4]);

            Spy spy = new Spy(id, firstName, lastName, codeNumber);

            return spy;
        }
    }
}
