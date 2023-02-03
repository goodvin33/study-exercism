using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public static class SimpleCalculator
    {
        public static string Calculate(int operand1, int operand2, string operation) =>   operation switch
                {
                    "+" => $"{operand1} {operation} {operand2} = {(operand1 + operand2)}",
                    "/" => operand2 == 0 ? "Division by zero is not allowed." : $"{operand1} {operation} {operand2} = {(operand1 / operand2)}",
                    "*" => $"{operand1} {operation} {operand2} = {(operand1 * operand2)}",
                    null => throw new ArgumentNullException(),
                    "" => throw new ArgumentException(),
                    _ => throw new ArgumentOutOfRangeException()
                };
            
            
    }
}
