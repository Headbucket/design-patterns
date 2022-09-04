namespace AbstractFactory
{
    internal class CalculationUnitTotalizer: ICalculationUnit
    {
        public double calculate(int[] list)
        {
            double result = 0;
            foreach (var item in list)
                result += item;
            return result;
        }
    }
}
