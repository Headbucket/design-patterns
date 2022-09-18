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
