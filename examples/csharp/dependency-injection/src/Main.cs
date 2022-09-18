using DependencyInjection;

var printer = new Printer(new ConsoleWriter());

printer.PrintMessage("message 1");
Thread.Sleep(100);
printer.PrintMessage("message 2");
Thread.Sleep(1000);
printer.PrintMessage("message 3");