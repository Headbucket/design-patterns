namespace AbstractFactory
{
    internal class CalculationUnitTotalizer: ICalculationUnit
    {
        public double calculate(int[] list)
        {
            return list.Sum();
        }
    }
}
