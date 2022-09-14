using AbstractFactory;

int[] intList =  {1, 2, 3, 4};

for (int i = 0; i < 2; i++)
{
    IFactory factory;
    switch(i)
    {
        case 0:
            factory = new FactoryTotalizer();
            break;
        case 1:
            factory = new FactoryMediator();
            break;
        default:
            throw new ArgumentException("Factory not implemented.");            
    }   
    ICalculationUnit unit = factory.CreateCalculationUnit();
    IViewer viewer = factory.CreateViewer();
    Console.WriteLine(viewer.GetOutputString(unit.calculate(intList)));   
}



