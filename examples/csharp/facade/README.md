# Facade

## Example usage

**Main.cs**
```csharp src\Main.cs
using Facade;

SaverFacade facade = new SaverFacade(new CSVSaver(), new JSONSaver(), new XMLSaver());
Data data = new Data();
facade.SaveData(data);
```

## Facade

**SaverFacade.cs**
```csharp src\SaverFacade.cs
namespace Facade
{
    internal class SaverFacade
    {
        private CSVSaver _csvSaver;

        private JSONSaver _jsonSaver;

        private XMLSaver _xmlSaver;

        public SaverFacade(CSVSaver csvSaver, JSONSaver jsonSaver, XMLSaver xmlSaver)
        {
            this._csvSaver = csvSaver;
            this._jsonSaver = jsonSaver;
            this._xmlSaver = xmlSaver;
        }

        public void SaveData(Data data)
        {
            try
            {
                _jsonSaver.SaveToJSON(data);
                _xmlSaver.SaveToXML(data);
                _csvSaver.SaveToCSV(data);  
            } catch (Exception e)
            {
                Console.Write($"The following error occured while saving: {e}");
            }
        }
    }
}
```

## Classes

**Data.cs**
```csharp src\Data.cs
namespace Facade
{
    internal class Data
    {
    }
}
```

**CSVSaver.cs**
```csharp src\CSVSaver.cs
namespace Facade
{
    internal class CSVSaver
    {
        public void SaveToCSV(Data data)
        {
            Console.WriteLine("Save data to CSV...");            
            throw new Exception("Error while saving CSV!");            
        }
    }
}
```

**JSONSaver.cs**
```csharp src\JSONSaver.cs
namespace Facade
{
    internal class JSONSaver
    {
        public void SaveToJSON(Data data)
        {
            Console.WriteLine("Save data to JSON...");
            Console.WriteLine("JSON saved!");
        }
    }
}
```

**XMLSaver.cs**
```csharp src\XMLSaver.cs
namespace Facade
{
    internal class XMLSaver
    {
        public void SaveToXML(Data data)
        {
            Console.WriteLine("Save data to XML...");
            Console.WriteLine("XML saved!");
        }
    }
}
```
