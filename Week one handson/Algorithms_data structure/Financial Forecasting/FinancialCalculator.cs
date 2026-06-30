using System;

namespace FinancialForecasting
{
    class FinancialCalculator
    {
        public static double CalculateFutureValue(double currentValue, double growthRate, int years)
        {
            // Base Case
            if (years == 0)
            {
                return currentValue;
            }

            // Recursive Call
            return CalculateFutureValue(
                currentValue * (1 + growthRate),
                growthRate,
                years - 1
            );
        }
    }
}