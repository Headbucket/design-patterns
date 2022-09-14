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
