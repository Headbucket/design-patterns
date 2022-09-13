namespace NullObject
{
    internal interface IDAO
    {
        public Customers getUsersByName(string firstName, string lastName);

        public void saveCustomer(Customer customer);
    }
}
