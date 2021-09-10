using System;
using Homework1;
using Xunit;

namespace TestProject1
{
    public class Tests
    {
        [Theory]
        [InlineData(1,CalculatorOperation.Plus,2,3)]
        public void SumIsCorrect(int val1,CalculatorOperation operation,int val2, int expected)
        {
            var result = Calculator.Calculate(val1, operation, val2);
            Assert.Equal(expected,result);
        }
        
        [Theory]
        [InlineData(6,CalculatorOperation.Minus,2,4)]
        public void MinusIsCorrect(int val1,CalculatorOperation operation,int val2, int expected)
        {
            var result = Calculator.Calculate(val1, operation, val2);
            Assert.Equal(expected,result);
        }
        [Theory]
        [InlineData(2,CalculatorOperation.Multiply,7,14)]
        public void MultiplyIsCorrect(int val1,CalculatorOperation operation,int val2, int expected)
        {
            var result = Calculator.Calculate(val1, operation, val2);
            Assert.Equal(expected,result);
        }
        
        [Theory]
        [InlineData(6,CalculatorOperation.Divide,2,3)]
        public void DivideIsCorrect(int val1,CalculatorOperation operation,int val2, int expected)
        {
            var result = Calculator.Calculate(val1, operation, val2);
            Assert.Equal(expected,result);
        }
        
        [Theory]
        [InlineData(new[]{"6", "*" ,"2"},0)]
        public void ParserValuesAreCorrectTest(string[] args,int expected)
        {
            var result = Parser.ParseCalcArguments(args, out var val1, out var operation, out var val2);
            Assert.Equal(expected,result);
        }
        
        [Theory]
        [InlineData(new[]{"x", "+" ,"2"},2)]
        public void ParserValuesAreIncorrectTest(string[] args,int expected)
        {
            var result = Parser.ParseCalcArguments(args, out var val1, out var operation, out var val2);
            Assert.Equal(expected,result);
        }
        
        [Theory]
        [InlineData(new[]{"1", "^" ,"2"},3)]
        public void ParserOperationIsIncorrectTest(string[] args, int expected)
        {
            var result = Parser.ParseCalcArguments(args, out var val1, out var operation, out var val2);
            Assert.Equal(expected,result);
        }
        
        [Theory]
        [InlineData(new[]{"1", "/" ,"2"},0)]
        public void ParserOperationIsCorrectTest(string[] args, int expected)
        {
            var result = Parser.ParseCalcArguments(args, out var val1, out var operation, out var val2);
            Assert.Equal(expected,result);
        }
        
        [Theory]
        [InlineData(new[]{"1", "-" ,"2","3"},1)]
        public void ParserLengthIsIncorrectTest(string[] args, int expected)
        {
            var result = Parser.ParseCalcArguments(args, out var val1, out var operation, out var val2);
            Assert.Equal(expected,result);
        }
        
        [Theory]
        [InlineData(new[]{"f", "+" ,"2"},2)]
        public void MainIncorrectInput(string[] args, int expected)
        {
            var result = Program.Main(args);
            Assert.Equal(expected,result);
        }
        
        [Theory]
        [InlineData(new[]{"1", "+" ,"2"},0)]
        public void MainCorrectInput(string[] args, int expected)
        {
            var result = Program.Main(args);
            Assert.Equal(expected,result);
        }
    }
}