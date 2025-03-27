namespace Routers;

/// <summary>
/// Reading from and writing to a file.
/// </summary>
public class File
{
    /// <summary>
    /// Read file.
    /// </summary>
    /// <param name="path">Path to file.</param>
    /// <param name="data">Class for storing data about routers.</param>
    public void Read(string path, DataStorage data)
    {
        using (StreamReader reader = new("TestFile.txt"))
        {
            string text = reader.ReadToEnd();
            List<char> name = new();
            bool nameEntered = false;
            for (var i = 0; i < text.Length; i++)
            {
                if (!nameEntered && text[i] != ':')
                {
                    name.Add(text[i]);
                }
                else if (text[i] == ':')
                {
                    nameEntered = true;
                    continue;
                }
                //else if ()
            }
        }
    }
}
