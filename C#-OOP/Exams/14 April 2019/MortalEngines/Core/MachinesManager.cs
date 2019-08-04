namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Common;
    using MortalEngines.Entities;
    using MortalEngines.Entities.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class MachinesManager : IMachinesManager
    {
        private List<Pilot> pilots;
        private List<IMachine> machines;

        public MachinesManager()
        {
            this.pilots = new List<Pilot>();
            this.machines = new List<IMachine>();
        }

        public string HirePilot(string name)
        {

            if (this.pilots.Any(x => x.Name == name))
            {
                return string.Format(OutputMessages.PilotExists, name);
            }

            else
            {
                this.pilots.Add(new Pilot(name));

                return string.Format(OutputMessages.PilotHired, name);
            }
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            var tank = new Tank(name, attackPoints, defensePoints);

            if (this.machines.Contains(tank))
            {
                return string.Format(OutputMessages.MachineExists, name);
            }

            else
            {
                this.machines.Add(tank);
                return string.Format(OutputMessages.TankManufactured, name, tank.AttackPoints, tank.DefensePoints);
            }

        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            if (this.machines.Any(x => x.Name == name && x.GetType().Name == nameof(Fighter)))
            {
                return string.Format(OutputMessages.MachineExists, name);
            }

            IFighter fighter = new Fighter(name, attackPoints, defensePoints);
            this.machines.Add(fighter);

            return string.Format(OutputMessages.FighterManufactured, name, fighter.AttackPoints, fighter.DefensePoints, fighter.AggressiveMode == true ? "ON" : "OFF");
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            IPilot pilot = this.pilots.FirstOrDefault(x => x.Name == selectedPilotName);
            var machine = this.machines.FirstOrDefault(x => x.Name == selectedMachineName);

            if (pilot == null)
            {
                return string.Format(OutputMessages.PilotNotFound, selectedPilotName);
            }

            else if (machine == null)
            {
                return string.Format(OutputMessages.MachineNotFound, selectedMachineName);
            }

            else if (machine.Pilot != null)
            {
                return string.Format(OutputMessages.MachineHasPilotAlready, selectedMachineName);
            }
            machine.Pilot = pilot;
            pilot.AddMachine(machine);

            return string.Format(OutputMessages.MachineEngaged, selectedPilotName, selectedMachineName);
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            var attackingMachine = this.machines.FirstOrDefault(x => x.Name == attackingMachineName);
            var defendingMachine = this.machines.FirstOrDefault(x => x.Name == defendingMachineName);

            if (attackingMachine==null)
            {
                return string.Format(OutputMessages.MachineNotFound, attackingMachineName);
            }

            if (defendingMachine == null)
            {
                return string.Format(OutputMessages.MachineNotFound, defendingMachineName);
            }

            if (attackingMachine.HealthPoints<=0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, attackingMachine);
            }

            if (defendingMachine.HealthPoints <= 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, defendingMachine);
            }

            attackingMachine.Attack(defendingMachine);

            return string.Format(OutputMessages.AttackSuccessful, defendingMachine.Name, attackingMachine.Name, defendingMachine.HealthPoints);
        }

        public string PilotReport(string pilotReporting)
        {
            var pilot = this.pilots.FirstOrDefault(x => x.Name == pilotReporting);

            return pilot.Report();
        }

        public string MachineReport(string machineName)
        {
            var machine = this.machines.FirstOrDefault(x => x.Name == machineName);

            return machine.ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            if (this.machines.Any(x => x.Name == fighterName && x.GetType().Name == nameof(Fighter)))
            {
                var fighter = (Fighter)this.machines.First(x => x.Name == fighterName);

                fighter.ToggleAggressiveMode();

                return string.Format(OutputMessages.FighterOperationSuccessful, fighterName);
            }

            return string.Format(OutputMessages.MachineNotFound, fighterName);
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            if (this.machines.Any(x => x.Name == tankName && x.GetType().Name == nameof(Tank)))
            {
                var tank = (Tank)this.machines.First(x => x.Name == tankName);

                tank.ToggleDefenseMode();

                return string.Format(OutputMessages.TankOperationSuccessful, tankName);
            }

            return string.Format(OutputMessages.MachineNotFound, tankName);
        }
    }
}