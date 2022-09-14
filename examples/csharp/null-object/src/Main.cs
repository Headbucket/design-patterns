using NullObject;


string[] daoTypes = { "SQLITE", "MSSQL", "POSTGRESQL" };

foreach (var daoType in daoTypes)
{
    IDAO dao = DAOFactory.CreateDAO(daoType);
    dao.saveCustomer(new Customer());
    Customers customers = dao.getUsersByName("Peter", "Pane");
    Console.WriteLine($"Customers found in {daoType}: {customers.Count}");
}