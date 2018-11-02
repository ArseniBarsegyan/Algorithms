using Xunit;

namespace MathAlgorithms.Tests
{
    public class FactorialTests
    {
        [Fact]
        public void RecursiveFactorialReturnsCorrectValueOfOne()
        {
            int expected = 1;
            int actual = Maths.RecursiveFactorial(1);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LoopFactorialReturnsCorrectValueOfOne()
        {
            int expected = 1;
            int actual = Maths.LoopFactorial(1);
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
        public void LoopFactorialReturnsCorrectValueForMinusValue()
        {
            int expected = 1;
            int actual = Maths.LoopFactorial(-1);
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
        public void LoopFactorialReturnsCorrectValue()
        {
            int expected = 3628800;
            int actual = Maths.LoopFactorial(10);
            Assert.Equal(expected, actual);
        }
    }
}
