using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            double foodMoneyPerDay = double.Parse(Console.ReadLine());
            double souvenirsMoneyPerDay = double.Parse(Console.ReadLine());
            double hotelMoneyPerDay = double.Parse(Console.ReadLine());

            double totalGasMoney = (420.00 / 100.00 * 7.00);
            double totalGasMoney2 = totalGasMoney * 1.85;
            double totalFoodMoney = 3 * foodMoneyPerDay;
            double totalSouvenirMoney = 3 * souvenirsMoneyPerDay;
            double totalHotelMoney = hotelMoneyPerDay * 0.90 + hotelMoneyPerDay * 0.85 + hotelMoneyPerDay * 0.80;

            double totalMoneyNeeded = totalGasMoney2 + totalFoodMoney + totalSouvenirMoney + totalHotelMoney;

            Console.WriteLine($"Money needed: {totalMoneyNeeded:F2}");

        }
    }
}
