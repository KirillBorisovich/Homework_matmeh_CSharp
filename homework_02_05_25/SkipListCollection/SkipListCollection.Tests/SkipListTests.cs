namespace SkipListCollection.Tests
{
    public class SkipListTests
    {
        private SkipList<int> list;

        [SetUp]
        public void Setup()
        {
            this.list = new();
        }

        [Test]
        public void Test1()
        {
            this.list.Contains(1);
            this.list.Add(1);
            this.list.Add(3);
            this.list.Add(2);
            Assert.Pass();
        }
    }
}
