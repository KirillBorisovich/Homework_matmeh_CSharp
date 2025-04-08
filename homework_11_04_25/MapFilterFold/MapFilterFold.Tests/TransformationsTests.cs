namespace MapFilterFold.Tests
{
    public class Tests
    {
        private List<int> list = new() { 1, 2, 3 };

        [Test]
        public void MapTest()
        {
            List<int> sample = new() { 2, 4, 6 };
            bool result = true;

            foreach (var item in Transformations.Map(this.list, x => x * 2))
            {
                if (item % 2 != 0)
                {
                    result = false;
                    break;
                }
            }

            Assert.That(result, Is.True);
        }

        [Test]
        public void FilterTest()
        {
            bool result = false;
            var resultList = Transformations.Filter(this.list, x => x % 2 == 0);
            if (resultList.Count == 1 && resultList[0] == 2)
            {
                result = true;
            }

            Assert.That(result, Is.True);
        }

        [Test]
        public void FoldTest()
        {
            Assert.That(Transformations.Fold(this.list, 1, (acc, elem) => acc * elem),
                Is.EqualTo(2));
        }
    }
}
