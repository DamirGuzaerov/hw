using System;

namespace Homework1
{
    public static class Parser
    {
        private const int WrongArgLength = 1;
        private const int WrongArgFormat = 2;
        private const int WrongArgOperationFormat = 3;

        public static int ParseCalcArguments(string[] args, out int val1, out CalculatorOperation operation,
            out int val2)
        {
            var isVal1 = int.TryParse(args[0], out val1);
            var isVal2 = int.TryParse(args[2], out val2);

            if (!TryParseOperationOrQuit(args[1], out operation)) return WrongArgOperationFormat;
            if (!CheckArgLength(args.Length)) return WrongArgLength;
            if (!TryParseOrQuit(args[0], isVal1) || !TryParseOrQuit(args[2], isVal2)) return WrongArgFormat;

            return 0;
        }

        private static bool CheckArgLength(int length)
        {
            if (length == 3) return true;
            Console.WriteLine($"The program requires 3 CLI arguments but {length} provided");
            return false;
        }

        private static bool TryParseOrQuit(string args, bool isValInt)
        {
            if (isValInt) return true;
            Console.WriteLine($"Val is not int : {args}");
            return false;
        }

        private static bool TryParseOperationOrQuit(string arg, out CalculatorOperation operation)
        {
            operation = arg switch
            {
                "+" => CalculatorOperation.Plus,
                "-" => CalculatorOperation.Minus,
                "*" => CalculatorOperation.Multiply,
                "/" => CalculatorOperation.Divide,
                _ => CalculatorOperation.UnidentifiedSign
            };

            return operation != CalculatorOperation.UnidentifiedSign;
        }
    }
}