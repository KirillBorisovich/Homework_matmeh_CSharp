using LZW;

string path = args[0];
string keyEvents = args[0];

if (!File.Exists(path))
{
    Console.WriteLine("The file does not exist\n");
    return -1;
}

switch (keyEvents)
{
    case "-c":
        LZWTransform.Compress(path);
        break;
    case "-u":
        if (path.Substring(path.Length - 7) != ".zipped")
        {
            Console.WriteLine("Incorrect extension for uncopression\n");
            return -1;
        }

        LZWTransform.Uncompress(path);
        break;
}

Console.WriteLine("All good!\n");

return 0;