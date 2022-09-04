namespace AbstractFactory
{
    internal class CalculationUnitMediator : ICalculationUnit
    {
        public double calculate(int[] list)
        {
            double result = 0;
            foreach (var item in list)
                result += item;
            if (list.Length > 0)
                result /= list.Length;
            return result;
        }
    }
}
