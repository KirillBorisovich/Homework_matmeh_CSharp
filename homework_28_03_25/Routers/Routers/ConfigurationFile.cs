namespace Routers;

/// <summary>
/// Reading from and writing to a configuration file.
/// </summary>
public class ConfigurationFile
{
    /// <summary>
    /// Reading a configuration file.
    /// </summary>
    /// <param name="path">Path to file.</param>
    /// <param name="data">Data warehouse.</param>
    public static void Read(string path, DataStorage data)
    {
        var lines = File.ReadAllLines(path);
        foreach (var line in lines)
        {
            ParseLine(line, data);
        }

        void ParseLine(string line, DataStorage data)
        {
            List<char> routerName = new();
            List<char> connectionWith = new();
            List<char> bandwidth = new();
            var wasColon = false;
            var wasOpenBracket = false;

            foreach (var item in line)
            {
                switch (item)
                {
                    case ' ':
                        continue;
                    case ',':
                        continue;
                    case ':':
                        wasColon = true;
                        continue;
                    case '(':
                        wasOpenBracket = true;
                        continue;
                    case ')':
                        wasOpenBracket = false;
                        data.AddConnectionFromFile(
                            new string(routerName.ToArray()),
                            new string(connectionWith.ToArray()),
                            int.Parse(new string(bandwidth.ToArray())));
                        connectionWith.Clear();
                        bandwidth.Clear();
                        continue;
                }

                if (!wasColon)
                {
                    routerName.Add(item);
                }
                else if (!wasOpenBracket)
                {
                    connectionWith.Add(item);
                }
                else if (wasOpenBracket)
                {
                    bandwidth.Add(item);
                }
            }
        }
    }

    /// <summary>
    /// Write configurations to file.
    /// </summary>
    /// <param name="path">Path to file.</param>
    /// <param name="data">Data warehouse.</param>
    public static void Write(string path, List<string> data)
    {
        using StreamWriter writer = new StreamWriter(path);
        foreach (var item in data)
        {
            writer.WriteLine(item);
        }
    }
}
