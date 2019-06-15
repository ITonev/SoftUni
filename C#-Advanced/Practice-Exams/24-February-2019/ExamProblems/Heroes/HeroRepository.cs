using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes
{
    public class HeroRepository
    {
        private List<Hero> heroes;

        public int Count => this.heroes.Count;

        public HeroRepository()
        {
            this.heroes = new List<Hero>();
        }

        public void Add(Hero hero)
        {
            if (!this.heroes.Contains(hero))
            {
                this.heroes.Add(hero);
            }
        }

        public void Remove(string name)
        {
            var hero = this.heroes.FirstOrDefault(x => x.Name == name);

            if (hero!=null)
            {
                this.heroes.Remove(hero);
            }
        }

        public Hero GetHeroWithHighestStrength()
        {
            var hero = this.heroes.OrderByDescending(x => x.Item.Strength).First();

            return hero;
        }

        public Hero GetHeroWithHighestAbility()
        {
            var hero = this.heroes.OrderByDescending(x => x.Item.Ability).First();

            return hero;
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            var hero = this.heroes.OrderByDescending(x => x.Item.Intelligence).First();

            return hero;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var hero in this.heroes)
            {
                sb.AppendLine(hero.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
