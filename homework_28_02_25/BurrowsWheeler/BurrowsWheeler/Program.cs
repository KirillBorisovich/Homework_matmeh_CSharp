using BurrowsWheeler;

BurrowsWheelerTransformations.DirectTransformation asdas = new("BANANA");
(string result, int index) = asdas.Transformation();
Console.WriteLine($"{result}, {index}");