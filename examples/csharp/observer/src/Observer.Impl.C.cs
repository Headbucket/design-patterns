namespace Observer
{
    internal class ObserverC : IObserver
    {
        public void Update(Customers customers)
        {
            Console.WriteLine("Output from ObserverC");
            Console.WriteLine($"Number of customers: {customers.Count}");
            Console.WriteLine();
        }        
    }
}
