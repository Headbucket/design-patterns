namespace AbstractFactory
{
    internal class FactoryTotalizer: IFactory
    {
        public ICalculationUnit CreateCalculationUnit()
        {
            return new CalculationUnitTotalizer();
        }

        public IViewer CreateViewer()
        {
            return new ViewerTotal();
        }
    }
}
