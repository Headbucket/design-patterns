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
