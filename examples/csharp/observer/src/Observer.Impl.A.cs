namespace Observer
{
    internal class ObserverA : IObserver
    {
        public void Update(Customers customers)
        {
            Console.WriteLine("Output from ObserverA");
            foreach (var customer in customers)
            {
                Console.WriteLine($"Name: {customer.Name}, Salery: {customer.Salery}");
            }
            Console.WriteLine();
        }
    }
}
