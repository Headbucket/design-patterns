namespace Observer
{
    internal class ObserverC : IObserver
    {
        public void Update(Customers customers)
        {
            Console.WriteLine("Output from ObserverB");
            Console.WriteLine("Number of customers: {0}", customers.Count);
            Console.WriteLine();
        }        
    }
}
