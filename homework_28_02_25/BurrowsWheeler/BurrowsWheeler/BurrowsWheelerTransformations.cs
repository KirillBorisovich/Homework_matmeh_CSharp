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
            var arrayChars = new char[len];
            var indexChars = new int[len];
            var result = new char[len];

            for (var i = 0; i < len; i++)
            {
                arrayChars[i] = this.str[i];
                indexChars[i] = i;
            }

            Array.Sort(arrayChars, indexChars);

            for (var i = 0; i < len; i++)
            {
                result[i] = this.str[(indexChars[i] - 1 + len) % len];
            }

            return (new string(result), indexChars[0]);
        }
    }
}
