# Dependency injection

## Example usage

**Main.cs**
```csharp src\Main.cs
using DependencyInjection;

var printer = new Printer(new ConsoleWriter());

printer.PrintMessage("message 1");
Thread.Sleep(100);
printer.PrintMessage("message 2");
Thread.Sleep(1000);
printer.PrintMessage("message 3");
```

## Printer class

**Printer.cs**
```csharp src\Printer.cs
namespace DependencyInjection
{
    internal class Printer
    {
        private readonly IConsoleWriter _writer;

        public Printer(IConsoleWriter writer)
        {
            _writer = writer;
        }

        public void PrintMessage(string message)
        {
            _writer.Write(message);
        }
    }
}
```

## Dependency

**ConsoleWriter.Intf.cs**
```csharp src\ConsoleWriter.Intf.cs
namespace DependencyInjection
{
    internal interface IConsoleWriter
    {
        public void Write(string message);
    }
}
```

**ConsoleWriter.Impl.cs**
```csharp src\ConsoleWriter.Impl.cs
namespace DependencyInjection
{
    internal class ConsoleWriter : IConsoleWriter
    {
        public void Write(string message)
        {
            Console.WriteLine(String.Format("{0:yyyy-MM-dd HH:mm:ss:fff}: {1}", DateTime.Now, message));
        }
    }
}
```