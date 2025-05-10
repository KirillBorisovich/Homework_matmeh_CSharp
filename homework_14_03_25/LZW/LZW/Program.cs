// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using LZW;

Console.WriteLine("LZW\n");

string path = args[0];
string keyEvents = args[1];

if (!File.Exists(path))
{
    Console.WriteLine("The file does not exist\n");
    return -1;
}

switch (keyEvents)
{
    case "-c":
        if (path.Substring(path.Length - 7) == ".zipped")
        {
            Console.WriteLine("The file is already compressed\n");
            return -2;
        }

        var coefficient = LZWTransform.Compress(path);
        Console.WriteLine($"Coefficient without BWT: {coefficient.WithoutBWT}\n");
        Console.WriteLine($"Coefficient with BWT: {coefficient.WithBWT}\n");
        break;
    case "-u":
        if (path.Substring(path.Length - 7) != ".zipped")
        {
            Console.WriteLine("Incorrect extension for uncopression\n");
            return -3;
        }

        LZWTransform.Uncompress(path);
        Console.WriteLine("All good!\n");
        break;
}

return 0;