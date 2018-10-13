using Xunit;

namespace MathAlgorithms.Tests
{
    public class Factorial
    {
        [Fact]
        public void RecursiveFactorialReturnsCorrectValueOfOne()
        {
            int expected = 1;
            int actual = Maths.RecursiveFactorial(1);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CycleFactorialReturnsCorrectValueOfOne()
        {
            int expected = 1;
            int actual = Maths.CycleFactorial(1);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RecursiveFactorialReturnsCorrectValueForMinusValue()
        {
            int expected = 1;
            int actual = Maths.RecursiveFactorial(-1);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CycleFactorialReturnsCorrectValueForMinusValue()
        {
            int expected = 1;
            int actual = Maths.CycleFactorial(-1);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RecursiveFactorialReturnsCorrectValue()
        {
            int expected = 3628800;
            int actual = Maths.RecursiveFactorial(10);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CycleFactorialReturnsCorrectValue()
        {
            int expected = 3628800;
            int actual = Maths.CycleFactorial(10);
            Assert.Equal(expected, actual);
        }
    }
}
