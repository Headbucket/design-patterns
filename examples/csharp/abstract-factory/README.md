# Abstract factory

## Example usage

**Main.cs**
```csharp src\Main.cs
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
```

## Factory

**Factory.Intf.cs**
```csharp src\Factory.Intf.cs
namespace AbstractFactory
{
    internal interface IFactory
    {
        public ICalculationUnit CreateCalculationUnit();
        public IViewer CreateViewer();
    }
}
```

**Factory.Impl.Totalizer.cs**
```csharp src\Factory.Impl.Totalizer.cs
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
```

**Factory.Impl.Mediator.cs**
```csharp src\Factory.Impl.Mediator.cs
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
```

## Interfaces & Classes
**CalculationUnit.Intf.cs**
```csharp src\CalculationUnit.Intf.cs
namespace AbstractFactory
{
    internal interface ICalculationUnit
    {
        public double calculate(int[] list);        
    }
}
```

**CalculationUnit.Impl.Totalizer.cs**
```csharp src\CalculationUnit.Impl.Totalizer.cs
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
```

**CalculationUnit.Impl.Mediator.cs**
```csharp src\CalculationUnit.Impl.Mediator.cs
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
```

**Viewer.Intf.cs**
```csharp src\Viewer.Intf.cs
namespace AbstractFactory
{
    internal interface IViewer
    {
        public string GetOutputString(double x);
    }
}
```

**Viewer.Impl.Total.cs**
```csharp src\Viewer.Impl.Total.cs
namespace AbstractFactory
{
    internal class ViewerTotal: IViewer
    {
        public string GetOutputString(double x)
        {
            return $"Total value: {x}";
        }
    }
}
```

**Viewer.Impl.Mean.cs**
```csharp src\Viewer.Impl.Mean.cs
namespace AbstractFactory
{
    internal class ViewerMean: IViewer
    {
        public string GetOutputString(double x)
        {
            return $"Mean value: {x}";
        }
    }
}
```