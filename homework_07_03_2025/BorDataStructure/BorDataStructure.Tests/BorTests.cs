namespace BorDataStructure.Tests
{
    public class Tests
    {
        private Bor _bor;

        [SetUp]
        public void Setup()
        {
            this._bor = new Bor();
            this._bor.Add("qwer");
        }

        [Test]
        public void TestAdd()
        {
            Assert.That(this._bor.Add("qwer"), Is.EqualTo(false));
            Assert.That(this._bor.Add("qwe"), Is.EqualTo(true));
            Assert.That(this._bor.Add("qwe"), Is.EqualTo(false));
        }

        [Test]
        public void TestContains()
        {
            Assert.That(this._bor.Contains("qwer"), Is.EqualTo(true));
            Assert.That(this._bor.Contains("qwe"), Is.EqualTo(false));
        }

        [Test]
        public void TestRemove()
        {
            Assert.That(this._bor.Add("qwe"), Is.EqualTo(true));
            Assert.That(this._bor.Remove("qwer"), Is.EqualTo(true));
            Assert.That(this._bor.Remove("qwer"), Is.EqualTo(false));
            Assert.That(this._bor.Contains("qwer"), Is.EqualTo(false));
            Assert.That(this._bor.Contains("qwe"), Is.EqualTo(true));

            Assert.That(this._bor.Add("qwer"), Is.EqualTo(true));
            Assert.That(this._bor.Remove("qwe"), Is.EqualTo(true));
            Assert.That(this._bor.Remove("qwe"), Is.EqualTo(false));
            Assert.That(this._bor.Contains("qwer"), Is.EqualTo(true));
            Assert.That(this._bor.Contains("qwe"), Is.EqualTo(false));
        }

        [Test]
        public void TestHowManyStartsWithPrefix()
        {
            Assert.That(this._bor.HowManyStartsWithPrefix("qw"), Is.EqualTo(1));
            Assert.That(this._bor.Add("qwe"), Is.EqualTo(true));
            Assert.That(this._bor.HowManyStartsWithPrefix("qw"), Is.EqualTo(2));
            Assert.That(this._bor.Remove("qwer"), Is.EqualTo(true));
            Assert.That(this._bor.HowManyStartsWithPrefix("qw"), Is.EqualTo(1));
        }
    }
}
