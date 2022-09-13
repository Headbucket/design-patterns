using NullObject;


string[] daoTypes = { "SQLITE", "MSSQL", "POSTGRESQL" };

foreach (var daoType in daoTypes)
{
    IDAO dao = DAOFactory.CreateDAO(daoType);
    dao.saveCustomer(new Customer());
    Customers customers = dao.getUsersByName("Peter", "Pane");
    Console.WriteLine(String.Format("Customers found in {0}: {1}", daoType, customers.Count));
}