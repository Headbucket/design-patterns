namespace NullObject
{
    internal sealed class DAONullObject : IDAO
    {
        private static DAONullObject? _instance;

        public static DAONullObject GetInstance()
        {
            if (_instance is null)
            {
                _instance = new DAONullObject();
            }
            return _instance;
        }

        public Customers getUsersByName(string firstName, string lastName)
        {
            return new Customers();
        }

        public void saveCustomer(Customer customer)
        {            
        }
    }
}
