using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

using MXGP.Models.Races;
using MXGP.Repositories;
using MXGP.Models.Riders;
using MXGP.Core.Contracts;
using MXGP.Utilities.Messages;
using MXGP.Models.Motorcycles;
using MXGP.Models.Races.Contracts;
using MXGP.Models.Motorcycles.Contracts;

namespace MXGP.Core
{
    public class ChampionshipController : IChampionshipController
    {
        private MotorcycleRepository motorcycleRepository;
        private RaceRepository raceRepository;
        private RiderRepository riderRepository;

        public ChampionshipController()
        {
            this.motorcycleRepository = new MotorcycleRepository();
            this.raceRepository = new RaceRepository();
            this.riderRepository = new RiderRepository();
        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            var rider = this.riderRepository.GetByName(riderName);
            var motorcycle = this.motorcycleRepository.GetByName(motorcycleModel);

            if (rider == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, riderName));
            }

            if (motorcycle == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.MotorcycleNotFound, motorcycleModel));
            }

            rider.AddMotorcycle(motorcycle);

            return string.Format(OutputMessages.MotorcycleAdded, riderName, motorcycleModel);
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            var rider = this.riderRepository.GetByName(riderName);
            var race = this.raceRepository.GetByName(raceName);


            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (rider == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, riderName));
            }

            race.AddRider(rider);

            return string.Format(OutputMessages.RiderAdded, riderName, raceName);
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            if (this.motorcycleRepository.GetByName(model) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.MotorcycleExists, model));
            }

            IMotorcycle motorcycle;

            if (type == "Speed")
            {
                motorcycle = new SpeedMotorcycle(model, horsePower);
                this.motorcycleRepository.Add(motorcycle);
            }

            else if (type == "Power")
            {
                motorcycle = new PowerMotorcycle(model, horsePower);
                this.motorcycleRepository.Add(motorcycle);
            }

            return string.Format(OutputMessages.MotorcycleCreated, type, model);
        }

        public string CreateRace(string name, int laps)
        {
            if (this.raceRepository.GetByName(name) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            IRace race = new Race(name, laps);
            this.raceRepository.Add(race);

            return string.Format(OutputMessages.RaceCreated, name);

        }

        public string CreateRider(string riderName)
        {
            if (this.riderRepository.GetByName(riderName) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RiderExists, riderName));
            }

            var rider = new Rider(riderName);

            this.riderRepository.Add(rider);
            return string.Format(OutputMessages.RiderCreated, riderName);
        }

        public string StartRace(string raceName)
        {
            var race = this.raceRepository.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (race.Riders.Count<3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            var orderedRidersList = race.Riders
                .OrderByDescending(x => x.Motorcycle.CalculateRacePoints(race.Laps))
                .Take(3)
                .ToList();

            var firstRider = orderedRidersList[0];
            var secondRider = orderedRidersList[1];
            var thirdRider = orderedRidersList[2];

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format(OutputMessages.RiderFirstPosition, firstRider.Name, raceName))
                .AppendLine(string.Format(OutputMessages.RiderSecondPosition, secondRider.Name, raceName))
                .AppendLine(string.Format(OutputMessages.RiderThirdPosition, thirdRider.Name, raceName));

            this.raceRepository.Remove(race);

            return sb.ToString().TrimEnd();
        }
    }
}
