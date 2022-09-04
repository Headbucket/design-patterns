using FactoryMethod;

int[] list =  {1, 2, 3, 4};

ICalculationUnit unit1 = CalculationUnitFactory.CreateCalculationUnit(CalculationUnitFactory.CalculationUnitType.Totalizer);
Console.WriteLine(unit1.calculate(list).ToString());

ICalculationUnit unit2 = CalculationUnitFactory.CreateCalculationUnit(CalculationUnitFactory.CalculationUnitType.Mediator);
Console.WriteLine(unit2.calculate(list).ToString());