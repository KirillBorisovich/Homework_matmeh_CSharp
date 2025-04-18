namespace ParseTreeTask.Tests;

public class CalcTests
{
    [Test]
    public void CalculateExpressionRecursivelyTest()
    {
        using (StreamReader reader = new StreamReader("../../../validInputDataTest.txt"))
        {
            string content = reader.ReadToEnd();
            Calc expression = new(content);
            Console.WriteLine(expression.CalculateExpression());
            Assert.That(expression.CalculateExpression(), Is.EqualTo(13));
        }
    }
}
