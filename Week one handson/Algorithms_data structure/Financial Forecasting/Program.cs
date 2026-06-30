using System;

namespace FinancialForecasting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== Financial Forecasting =====");

            Console.Write("Enter Present Value: ");
            double presentValue = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Annual Growth Rate (%): ");
            double growthRate = Convert.ToDouble(Console.ReadLine()) / 100;

            Console.Write("Enter Number of Years: ");
            int years = Convert.ToInt32(Console.ReadLine());

            double futureValue = FinancialCalculator.CalculateFutureValue(
                presentValue,
                growthRate,
                years);

            Console.WriteLine();
            Console.WriteLine($"Future Value after {years} years = {futureValue:F2}");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}