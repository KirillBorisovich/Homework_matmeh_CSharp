namespace BurrowsWheeler;

class BurrowsWheelerTransformations
{
    public class DirectTransformation
    {
        public DirectTransformation(string str)
        {
            this.str = str;
        }

        private string str;

        public (string resultString, int indexLastElement) Transformation()
        {
            var len = this.str.Length;
            var shiftIndices = new int[len];
            var result = new char[len];

            for (var i = 0; i < len; i++)
            {
                shiftIndices[i] = i;
            }

            Array.Sort(shiftIndices, (a, b) =>
            {
                for (var i = 0; i < len; i++)
                {
                    var charA = this.str[(a + i) % len];
                    var charB = this.str[(b + i) % len];

                    if (charA != charB)
                    {
                        return charA.CompareTo(charB);
                    }
                }
                return 0;
            });

            for (var i = 0; i < len; i++)
            {
                result[i] = this.str[(shiftIndices[i] - 1 + len) % len];
            }

            return (new string(result), shiftIndices[0]);
        }
    }
}
