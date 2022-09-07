namespace AbstractFactory
{
    internal interface IFactory
    {
        public ICalculationUnit CreateCalculationUnit();
        public IViewer CreateViewer();
    }
}
