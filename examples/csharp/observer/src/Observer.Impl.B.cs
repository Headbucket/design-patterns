namespace Observer
{
    internal class ObserverB : IObserver
    {
        public void Update(Customers customers)
        {
            Console.WriteLine("Output from ObserverB");

            decimal? MaxSalery = null;
            string? Name = null;
            for (int i = 0; i < customers.Count; i++)            
            {
                if (i == 0)
                {
                    Name = customers[i].Name;
                    MaxSalery = customers[i].Salery;
                }
                else
                {
                    if (customers[i].Salery > MaxSalery)
                    {
                        Name = customers[i].Name;
                        MaxSalery = customers[i].Salery;
                    }
                }
            }

            if (Name != null)
            {
                Console.WriteLine("Customer with highest salery: {0}", Name);
            }

            Console.WriteLine();
        }
    }
}
