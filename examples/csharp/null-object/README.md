# Null Object

## Example usage

**Main.cs**
```csharp src\Main.cs
using NullObject;


string[] daoTypes = { "SQLITE", "MSSQL", "POSTGRESQL" };

foreach (var daoType in daoTypes)
{
    IDAO dao = DAOFactory.CreateDAO(daoType);
    dao.saveCustomer(new Customer());
    Customers customers = dao.getUsersByName("Peter", "Pane");
    Console.WriteLine($"Customers found in {daoType}: {customers.Count}");
}
```

**Console output**
```console
Customer saved in SQLite.
Customers found in SQLITE: 5
Customer saved in MSSQL.
Customers found in MSSQL: 1
Customers found in POSTGRESQL: 0
```

## Customer

**Customer.cs**
```csharp src\Customer.cs
namespace NullObject
{
    internal class Customer
    {
        public string? firstName { get; set; }

        public string? lastName { get; set; }
    }

    internal class Customers: List<Customer>
    { }
}
```

## Interface

**DAO.Intf.cs**
```csharp src\DAO.Intf.cs
namespace NullObject
{
    internal interface IDAO
    {
        public Customers getUsersByName(string firstName, string lastName);

        public void saveCustomer(Customer customer);
    }
}
```

## Implementations including null object

**DAO.Impl.NullObject.cs**
```csharp src\DAO.Impl.NullObject.cs
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
```

**DAO.Impl.MSSQL.cs**
```csharp src\DAO.Impl.MSSQL.cs
namespace NullObject
{
    internal class DAOMSSQL : IDAO
    {
        public Customers getUsersByName(string firstName, string lastName)
        {
            Customers result = new Customers();
            for (int i = 0; i < 1; i++)
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
            Console.WriteLine("Customer saved in MSSQL.");
        }
    }
}
```

**DAO.Impl.SQLite.cs**
```csharp src\DAO.Impl.SQLite.cs
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
```

## Factory

**DAO.Factory.cs**
```csharp src\DAO.Factory.cs
namespace NullObject
{
    internal class DAOFactory
    {
        public static IDAO CreateDAO(string daoType)
        {
            switch(daoType.ToUpper())
            {
                case "SQLITE":
                    {
                        return new DAOSQLite();                        
                    }
                case "MSSQL":
                    {
                        return new DAOMSSQL();
                    }
                default:
                    {
                        return DAONullObject.GetInstance();
                    }
            }
        }
    }
}
```