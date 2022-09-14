using System.Collections.Generic;

namespace Observer
{
    internal class ObserverB : IObserver
    {
        public void Update(Customers customers)
        {
            Console.WriteLine("Output from ObserverB");

            var customer = customers.MaxBy(x => x.Salery);

            if (customer is not null)
            {
                Console.WriteLine($"Customer with highest salery: {customer.Name}");
            }

            Console.WriteLine();
        }
    }
}
