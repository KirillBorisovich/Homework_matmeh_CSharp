// <copyright file="DataStorage.cs" company="Bengya Kirill">
// Copyright (c) Bengya Kirill under MIT License.
// </copyright>

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
        if (this.configuration.Count == 0)
        {
            throw new ConfigurationIsEmptyExpection();
        }

        var firstElement = this.configuration.ElementAt(0);
        var maxConnetcionFirstElement = GetConnectionByMaxBandwidth(firstElement.Value);
        Connection maxConnetcionFirstElementForAdding =
            new(maxConnetcionFirstElement.Name, maxConnetcionFirstElement.Bandwidth);
        AddConnection(
            this.optimalConfiguration,
            firstElement.Key,
            maxConnetcionFirstElementForAdding);
        firstElement.Value.Remove(maxConnetcionFirstElement);

        while (this.optimalConfiguration.Count != this.configuration.Count)
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
                    GetConnectionByMaxBandwidth(this.configuration[item.Key]);
                while (this.optimalConfiguration.ContainsKey(maxValueByItemInConfiguration.Name) &&
                    maxValueByItemInConfiguration.Bandwidth != -1)
                {
                    this.configuration[item.Key].Remove(maxValueByItemInConfiguration);
                    maxValueByItemInConfiguration = GetConnectionByMaxBandwidth(this.configuration[item.Key]);
                }

                if (maxValue.Bandwidth < maxValueByItemInConfiguration.Bandwidth)
                {
                    maxValue = maxValueByItemInConfiguration;
                    nameMaxElement = [.. item.Key];
                }
            }

            if (maxValue.Bandwidth == -1)
            {
                throw new DisconnectedGraphException();
            }

            var nameMaxElementString = new string(nameMaxElement.ToArray());
            Connection maxValueForAdding = new(maxValue.Name, maxValue.Bandwidth);

            this.configuration[nameMaxElementString].Remove(maxValue);

            AddConnection(this.optimalConfiguration, nameMaxElementString, maxValueForAdding);
        }

        return TranslateConfigurationIntoStrings();

        Connection GetConnectionByMaxBandwidth(List<Connection> connections)
        {
            if (connections.Count == 0)
            {
                return new Connection("-1", -1);
            }

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

        List<string> TranslateConfigurationIntoStrings()
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

                addingString = addingString.Remove(addingString.Length - 2, 2);

                result.Add(addingString);
            }

            return result;
        }
    }

    /// <summary>
    /// Add connection.
    /// </summary>
    /// <param name="routerName">The name of the router we are routing from.</param>
    /// <param name="connectionWith">The name of the router we are heading to.</param>
    /// <param name="bandwidth">Connection bandwidth.</param>
    public void AddConnectionFromFile(string routerName, string connectionWith, int bandwidth)
    {
        if (string.IsNullOrEmpty(routerName) ||
            string.IsNullOrEmpty(routerName) ||
            string.IsNullOrEmpty(routerName))
        {
            return;
        }

        var connection = new Connection(connectionWith, bandwidth);
        AddConnection(this.configuration, routerName, connection);
    }

    private static void AddConnection(
        Dictionary<string, List<Connection>> routers,
        string routerName,
        Connection connection)
    {
        if (string.IsNullOrEmpty(routerName))
        {
            return;
        }

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
