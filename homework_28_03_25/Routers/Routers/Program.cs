using Routers;

var pathToInputFile = args[0];
var pathToOutputFile = args[1];

if (!File.Exists(pathToInputFile))
{
    Console.WriteLine("The file does not exists.\n");
    return 0;
}

DataStorage data = new();

try
{
    ConfigurationFile.Read(pathToInputFile, data);
    ConfigurationFile.Write(pathToOutputFile, data.GenerateConfiguration());
}
catch (FormatException)
{
    Console.WriteLine("Incorrect number format in bandwidth.\n");
    return 0;
}
catch (OverflowException)
{
    Console.WriteLine("The number is too big or too small in the bandwidth.\n");
    return 0;
}
catch (ConfigurationIsEmptyExpection)
{
    Console.WriteLine("No configuration data available.\n");
    return 0;
}
catch (DisconnectedGraphException)
{
    Console.WriteLine("The graph is not connected.\n");
    return 0;
}

Console.WriteLine("The program completed successfully.\n");

return 0;

