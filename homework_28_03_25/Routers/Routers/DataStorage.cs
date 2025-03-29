namespace Routers;

/// <summary>
/// Storing data about router connections.
/// </summary>
public class DataStorage
{
    private Dictionary<string, List<Connection>> configuration = new();
    private Dictionary<string, List<Connection>> optimalConfiguration = new();

    /// <summary>
    /// Generate optimal configuration.
    /// </summary>
    /// <returns>Returns a list of strings with configurations.</returns>
    public List<string> GenerateConfiguration()
    {

        var firstElement = this.configuration.ElementAt(0);
        var maxConnetcionFirstElement = this.GetConnectionByMaxBandwidth(firstElement.Value);
        Connection maxConnetcionFirstElementForAdding =
            new(maxConnetcionFirstElement.Name, maxConnetcionFirstElement.Bandwidth);
        this.AddConnection(
            this.optimalConfiguration,
            firstElement.Key,
            maxConnetcionFirstElementForAdding);
        firstElement.Value.Remove(maxConnetcionFirstElement);
        var graphIsDisconnected = false;

        while (this.optimalConfiguration.Count != this.configuration.Count && !graphIsDisconnected)
        {
            Connection maxValue = new("0", -1);

            List<char> nameMaxElement = new();

            foreach (var item in this.optimalConfiguration)
            {
                if (this.configuration[item.Key].Count == 0)
                {
                    continue;
                }

                var maxValueByItemInConfiguration =
                    this.GetConnectionByMaxBandwidth(this.configuration[item.Key]);
                if ((maxValue.Bandwidth < maxValueByItemInConfiguration.Bandwidth) &&
                    !this.optimalConfiguration.ContainsKey(maxValueByItemInConfiguration.Name))
                {
                    maxValue = maxValueByItemInConfiguration;
                    nameMaxElement = [.. item.Key];
                }
            }

            if (maxValue.Bandwidth == -1)
            {
                //throw an exception here
                graphIsDisconnected = true;
                continue;
            }

            var nameMaxElementString = new string(nameMaxElement.ToArray());
            Connection maxValueForAdding = new(maxValue.Name, maxValue.Bandwidth);

            this.configuration[nameMaxElementString].Remove(maxValue);

            this.AddConnection(this.optimalConfiguration, nameMaxElementString, maxValueForAdding);
        }

        return this.TranslateConfigurationIntoStrings();
    }

    /// <summary>
    /// Add connection.
    /// </summary>
    /// <param name="routerName">The name of the router we are routing from.</param>
    /// <param name="connectionWith">The name of the router we are heading to.</param>
    /// <param name="bandwidth">Connection bandwidth.</param>
    public void AddConnectionFromFile(string routerName, string connectionWith, int bandwidth)
    {
        var connection = new Connection(connectionWith, bandwidth);
        this.AddConnection(this.configuration, routerName, connection);
    }

    private void AddConnection(
        Dictionary<string, List<Connection>> routers,
        string routerName,
        Connection connection)
    {
        if (!routers.ContainsKey(routerName))
        {
            routers.Add(routerName, new List<Connection>());
        }

        if (!routers.ContainsKey(connection.Name))
        {
            routers.Add(connection.Name, new List<Connection>());
        }

        routers[routerName].Add(connection);
    }

    private List<string> TranslateConfigurationIntoStrings()
    {
        List<string> result = new();

        foreach (var router in this.optimalConfiguration)
        {
            if (router.Value.Count == 0)
            {
                continue;
            }

            var addingString = $"{router.Key}: ";
            foreach (var connection in router.Value)
            {
                var tempString = $"{connection.Name} ({connection.Bandwidth}), ";
                addingString += tempString;
            }

            addingString = addingString.Remove(addingString.Length - 2, 1);

            result.Add(addingString);
        }

        return result;
    }

    private Connection GetConnectionByMaxBandwidth(List<Connection> connections)
    {
        var maxElement = connections[0];
        foreach (var item in connections)
        {
            if (maxElement.Bandwidth < item.Bandwidth)
            {
                maxElement = item;
            }
        }

        return maxElement;
    }

    private struct Connection(string name, int bandwidth)
    {
        /// <summary>
        /// Gets router name.
        /// </summary>
        public string Name { get; } = name;

        /// <summary>
        /// Gets router bandwidth.
        /// </summary>
        public int Bandwidth { get; } = bandwidth;
    }
}
