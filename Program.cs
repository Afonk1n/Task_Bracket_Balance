using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Brackets_Balance
{
    internal class Program
    {
        private static readonly Dictionary<char, char> Pairs = new Dictionary<char, char>()
        {
            {'{', '}'},
            {'(', ')'},
            {'[', ']'}
        };
        static void Main(string[] args)
        {
            Console.WriteLine(IsBalanced("()[]")); //true
            Console.WriteLine(IsBalanced("()[][{}]")); //true
            Console.WriteLine(IsBalanced("([][{}")); // false
            Console.ReadLine();
        }

        private static bool IsBalanced(string text) 
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            var stack = new Stack<char>();
            foreach (var symbol in text)
            {
                if (Pairs.ContainsKey(symbol))
                {
                    stack.Push(symbol);
                }
                else if (!Pairs.ContainsKey(symbol)) continue;
                else if (stack.Count == 0) return false;
                else if (Pairs[stack.Pop()] != symbol)
                {
                    return false;
                }
            }
            return stack.Count == 0;
        }
    }
}
