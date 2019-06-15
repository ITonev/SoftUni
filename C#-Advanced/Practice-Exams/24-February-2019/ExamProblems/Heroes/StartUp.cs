using System;

namespace Heroes
{
    public class StartUp
    {
        public static void Main()
        {
            HeroRepository repository = new HeroRepository();

            Item item = new Item(23, 35, 48);
            Console.WriteLine(item);

            Hero hero = new Hero("Hero Name", 24, item);
            Console.WriteLine(hero);

            repository.Add(hero);
            repository.Remove("Hero Name");

            Item secondItem = new Item(100, 20, 13);
            Hero secondHero = new Hero("Second Hero Name", 125, secondItem);

            repository.Add(hero);
            repository.Add(secondHero);

            var heroStrength = repository.GetHeroWithHighestStrength();
            var heroAbility = repository.GetHeroWithHighestAbility();
            var heroIntelligence = repository.GetHeroWithHighestIntelligence();

            Console.WriteLine(repository.Count);
            Console.WriteLine(repository);
        }
    }
}
