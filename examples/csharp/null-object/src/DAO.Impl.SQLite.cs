namespace NullObject
{
    internal class DAOSQLite : IDAO
    {
        public Customers getUsersByName(string firstName, string lastName)
        {
            Customers result = new Customers();  
            for (int i = 0; i < 5; i++)
            {
                result.Add(new Customer
                {
                    firstName = firstName,
                    lastName = lastName
                });
            }
            return result;
        }

        public void saveCustomer(Customer customer)
        {
            Console.WriteLine("Customer saved in SQLite.");
        }
    }
}
