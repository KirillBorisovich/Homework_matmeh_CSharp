namespace Routers.Tests
{
    public class DataStorageTest
    {
        private DataStorage data = new();

        [Test]
        public void GenerateConfigurationShouldReturnConfigurationIsEmptyExpectionTest()
        {
            Assert.Throws<ConfigurationIsEmptyExpection>(
                () => this.data.GenerateConfiguration());
        }

        [Test]
        public void GenerateConfigurationShouldReturnDisconnectedGraphExceptionTest()
        {
            ConfigurationFile.Read(
                "..\\..\\..\\disconnectedGraphInputFile.txt", 
                this.data);

            Assert.Throws<DisconnectedGraphException>(
                () => this.data.GenerateConfiguration());
        }
    }
}
