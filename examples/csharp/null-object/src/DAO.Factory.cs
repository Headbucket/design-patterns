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
