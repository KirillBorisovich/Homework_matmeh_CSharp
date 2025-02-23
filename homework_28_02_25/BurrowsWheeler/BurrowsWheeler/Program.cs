using BurrowsWheeler;

(string result, int index) = BurrowsWheelerTransformations.DirectTransformation("BANANA");

Console.WriteLine($"{result}, {index}");
Console.WriteLine($"{BurrowsWheelerTransformations.InverseTransformation(result, index)}");