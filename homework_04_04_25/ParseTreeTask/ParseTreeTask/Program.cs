using ParseTreeTask;

string filePath = "../../../input.txt";

try
{
    using (StreamReader reader = new StreamReader(filePath))
    {
        string content = reader.ReadToEnd();
        Calc expression = new(content);
        Console.Write("Parse tree: ");
        expression.PrintTree();
        Console.WriteLine($"\nResult: {expression.CalculateExpression()}\n");
    }
}
catch (FileNotFoundException)
{
    Console.WriteLine("File not found\n");
}
catch (IOException ex)
{
    Console.WriteLine($"Error reading file: {ex.Message}\n");
}
catch (StringIsEmptyException)
{
    Console.WriteLine("The expression is empty\n");
}
catch (FormatException)
{
    Console.WriteLine("Invalid expression structure\n");
}
catch (InvalidCharacterException)
{
    Console.WriteLine("Invalid characters\n");
}
