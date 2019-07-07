using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private const double baseCaloriesPerGram = 2;
        private const double whiteFlourModifier = 1.5;
        private const double wholegrainFlourModifier = 1.0;
        private const double crispyTechniqueModifier = 0.9;
        private const double chewyTechniqueModifier = 1.1;
        private const double homemadeTechniqueModifier = 1.0;

        private string flourType;
        private string bakingTechnique;
        private double weight;
        private double calories;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public double Calories => this.CaloriestCalculator();

        public string FlourType
        {
            get => this.flourType;

            private set
            {
                if (value.ToLower() != "wholegrain"
                    && value.ToLower() != "white")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            get => this.bakingTechnique;

            private set
            {
                if (value.ToLower() != "crispy"
                    && value.ToLower() != "chewy"
                    && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value;
            }
        }

        public double Weight
        {
            get => this.weight;

            private set
            {
                if (value < 0 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                this.weight = value;
            }
        }

        private double CaloriestCalculator()
        {
            double currentFlourModifier = 0;
            double currentBakingModifier = 0;

            switch (this.FlourType.ToLower())
            {
                case "white":
                    currentFlourModifier = whiteFlourModifier;
                    break;
                case "wholegrain":
                    currentFlourModifier = wholegrainFlourModifier;
                    break;
            }

            switch (this.BakingTechnique.ToLower())
            {
                case "crispy":
                    currentBakingModifier = crispyTechniqueModifier;
                    break;
                case "chewy":
                    currentBakingModifier = chewyTechniqueModifier;
                    break;
                case "homemade":
                    currentBakingModifier = homemadeTechniqueModifier;
                    break;
            }

            this.calories = baseCaloriesPerGram * this.weight * (currentBakingModifier * currentFlourModifier);

            return this.calories;
        }
    }
}
