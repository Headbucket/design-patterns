namespace Observer
{
    internal class ObserverA : IObserver
    {
        public void Update(Customers customers)
        {
            Console.WriteLine("Output from ObserverA");
            foreach (var customer in customers)
            {
                Console.WriteLine("Name: {0}, Salery: {1}", customer.Name, customer.Salery);
            }
            Console.WriteLine();
        }
    }
}
