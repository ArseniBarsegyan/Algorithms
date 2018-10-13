namespace MathAlgorithms
{
    public static class Maths
    {
        /// <summary>
        /// Count factorial of the number recursively.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static int RecursiveFactorial(int number)
        {
            if (number <= 1)
            {
                return 1;
            }
            return number * RecursiveFactorial(number - 1);
        }

        /// <summary>
        /// Count factorial with loop.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static int LoopFactorial(int number)
        {
            if (number <= 1)
            {
                return 1;
            }
            int result = number;
            for (int i = 1; i < number; i++)
            {
                result = result * i;
            }
            return result;
        }
    }
}
