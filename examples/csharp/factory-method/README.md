# Factory method

## Example usage

**Main.cs**
```csharp src\Main.cs
using FactoryMethod;

int[] list =  {1, 2, 3, 4};

ICalculationUnit unit1 = CalculationUnitFactory.CreateCalculationUnit(CalculationUnitFactory.CalculationUnitType.Totalizer);
Console.WriteLine(unit1.calculate(list).ToString());

ICalculationUnit unit2 = CalculationUnitFactory.CreateCalculationUnit(CalculationUnitFactory.CalculationUnitType.Mediator);
Console.WriteLine(unit2.calculate(list).ToString());
```

## Factory

**CalculationUnit.Factory.cs**
```csharp src\CalculationUnit.Factory.cs
namespace FactoryMethod
{
    internal class CalculationUnitFactory
    {
        public enum CalculationUnitType
        {
            Totalizer,
            Mediator
        }
        public static ICalculationUnit CreateCalculationUnit(CalculationUnitType cuType)
        {
            switch(cuType)
            {
                case CalculationUnitType.Totalizer:
                    {
                        return new CalculationUnitTotalizer();                        
                    }
                case CalculationUnitType.Mediator:
                    {
                        return new CalculationUnitMediator();
                    }
                default:
                    {
                        throw new ArgumentException("Calculation unit type not implemented.");
                    }
            }
        }
    }
}
```

## Interface & Classes

**CalculationUnit.Intf.cs**
```csharp src\CalculationUnit.Intf.cs
namespace FactoryMethod
{
    internal interface ICalculationUnit
    {
        public double calculate(int[] list);
    }
}
```

**CalculationUnit.Impl.Totalizer.cs**
```csharp src\CalculationUnit.Impl.Totalizer.cs
namespace FactoryMethod
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
```

**CalculationUnit.Impl.Mediator.cs**
```csharp src\CalculationUnit.Impl.Mediator.cs
namespace FactoryMethod
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
```