using Homework1;
using Xunit;

namespace TestProject1
{
    public class Tests
    {
        const int WrongArgLength = 1;
        const int WrongArgFormat = 2;
        const int WrongArgOperationFormat = 3;

        [Theory]
        [InlineData(1,CalculatorOperation.Plus,2,3)]
        [InlineData(6,CalculatorOperation.Minus,2,4)]
        [InlineData(2,CalculatorOperation.Multiply,7,14)]
        [InlineData(6,CalculatorOperation.Divide,2,3)]
        public void CalculateIsCorrect(int val1,CalculatorOperation operation,int val2, int expected)
        {
            var result = Calculator.Calculate(val1, operation, val2);
            Assert.Equal(expected,result);
        }
        
        [Theory]
        [InlineData(new[]{"6", "*" ,"2"},0)]
        [InlineData(new[]{"x", "+" ,"2"},WrongArgFormat)]
        public void ParserValuesAreCorrectTest(string[] args,int expected)
        {
            var result = Parser.ParseCalcArguments(args, out var val1, out var operation, out var val2);
            Assert.Equal(expected,result);
        }
        
        [Theory]
        [InlineData(new[]{"1", "^" ,"2"},WrongArgOperationFormat)]
        [InlineData(new[]{"1", "/" ,"2"},0)]
        public void ParserOperationIsIncorrectTest(string[] args, int expected)
        {
            var result = Parser.ParseCalcArguments(args, out var val1, out var operation, out var val2);
            Assert.Equal(expected,result);
        }
        
        [Theory]
        [InlineData(new[]{"1", "-" ,"2","3"},WrongArgLength)]
        public void ParserLengthIsIncorrectTest(string[] args, int expected)
        {
            var result = Parser.ParseCalcArguments(args, out var val1, out var operation, out var val2);
            Assert.Equal(expected,result);
        }
        
        [Theory]
        [InlineData(new[]{"f", "+" ,"2"},WrongArgFormat)]
        [InlineData(new[]{"1", "+" ,"2"},0)]
        public void MainIncorrectInput(string[] args, int expected)
        {
            var result = Program.Main(args);
            Assert.Equal(expected,result);
        }
    }
}