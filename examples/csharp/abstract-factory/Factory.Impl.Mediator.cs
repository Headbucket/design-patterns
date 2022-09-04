namespace AbstractFactory
{
    internal class FactoryMediator: IFactory
    {
        public ICalculationUnit CreateCalculationUnit()
        {
            return new CalculationUnitMediator();
        }

        public IViewer CreateViewer()
        {
            return new ViewerMean();
        }
    }
}
