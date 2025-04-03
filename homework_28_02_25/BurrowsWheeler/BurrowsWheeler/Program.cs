using BurrowsWheeler;

Console.WriteLine("Enter the word: ");
string? input = Console.ReadLine();

(string? result, int index) = BurrowsWheelerTransformations.DirectTransformation(input);

Console.WriteLine($"\nDirect transformation: {result}, {index}\n");
Console.WriteLine("Inverse transformation: " +
    $"{BurrowsWheelerTransformations.InverseTransformation(result, index)}\n");
