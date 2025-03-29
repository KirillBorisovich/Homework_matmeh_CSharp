using Routers;

DataStorage data = new();
ConfigurationFile.Read("C:\\Users\\Kiril\\OneDrive\\Рабочий стол\\test.txt", data);
var result = data.GenerateConfiguration();
ConfigurationFile.Write("C:\\Users\\Kiril\\OneDrive\\Рабочий стол\\test1.txt", result);