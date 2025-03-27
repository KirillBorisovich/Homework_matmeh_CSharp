namespace Routers;

public class DataStorage
{
    private List<Router> routers = new();

    /// <summary>
    /// Add connection.
    /// </summary>
    /// <param name="routerName">The name of the router we are routing from.</param>
    /// <param name="connectionWith">The name of the router we are heading to.</param>
    /// <param name="bandwidth">Connection bandwidth.</param>
    public void AddConnection(string routerName, string connectionWith, string bandwidth)
    {
        var connection = new Connection(connectionWith, bandwidth);

        var router = this.PresenceOfARouter(routerName);
        if (router.Name != "None")
        {
            router.Connections.Add(connection);
            return;
        }

        router = new Router(routerName);
        router.Connections.Add(connection);
        this.routers.Add(router);
    }

    private Router PresenceOfARouter(string name)
    {
        foreach (var item in this.routers)
        {
            if (item.Name == name)
            {
                return item;
            }
        }

        return new Router("None");
    }

    private struct Router(string name)
    {
        public string Name { get; } = name;

        public List<Connection> Connections { get; } = new();
    }

    /// <summary>
    /// A structure that stores information about a connection to another router.
    /// </summary>
    /// <param name="name">Router name.</param>
    /// <param name="bandwidth">Router bandwidth</param>
    private struct Connection(string name, string bandwidth)
    {
        /// <summary>
        /// Gets router name.
        /// </summary>
        public string Name { get; } = name;

        /// <summary>
        /// Gets router bandwidth.
        /// </summary>
        public string Bandwidth { get; } = bandwidth;
    }
}
