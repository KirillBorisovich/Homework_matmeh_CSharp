using LZW;

Console.WriteLine("LZW compression algorithm\n");

LZWTransform.Compress(@"C:\\Users\\Kiril\\OneDrive\\Рабочий стол\\text.txt");
LZWTransform.Uncompress(@"C:\\Users\\Kiril\\OneDrive\\Рабочий стол\\test.txt");