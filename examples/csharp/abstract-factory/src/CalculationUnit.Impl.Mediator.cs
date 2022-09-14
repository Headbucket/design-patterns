namespace AbstractFactory
{
    internal class CalculationUnitMediator : ICalculationUnit
    {
        public double calculate(int[] list)
        {
            return list.Length > 0 ? list.Average() : 0.0;
        }
    }
}
