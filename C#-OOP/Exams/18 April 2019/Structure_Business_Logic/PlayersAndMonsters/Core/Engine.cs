using PlayersAndMonsters.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        private ManagerController managerController;

        public Engine()
        {
            this.managerController = new ManagerController();
        }

        public void Run()
        {
            while (true)
            {
                var input = Console.ReadLine().Split();

                var command = input[0];

                if (command == "Exit")
                {
                    break;
                }

                try
                {
                    switch (command)
                    {
                        case "AddPlayer":
                            Console.WriteLine(this.managerController.AddPlayer(input[1], input[2]));
                            break;

                        case "AddCard":
                            Console.WriteLine(this.managerController.AddCard(input[1], input[2]));
                            break;

                        case "AddPlayerCard":
                            Console.WriteLine(this.managerController.AddPlayerCard(input[1], input[2]));
                            break;

                        case "Fight":
                            Console.WriteLine(this.managerController.Fight(input[1], input[2]));
                            break;

                        case "Report":
                            Console.WriteLine(this.managerController.Report());
                            break;

                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
    }
}

