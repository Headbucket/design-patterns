using Facade;

SaverFacade facade = new SaverFacade(new CSVSaver(), new JSONSaver(), new XMLSaver());
Data data = new Data();
facade.SaveData(data);