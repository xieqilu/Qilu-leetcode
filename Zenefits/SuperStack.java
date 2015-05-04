using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
 
namespace Solution
{
    class Solution
    {
        static void Main(string[] args)
        {
            var noCommands = Convert.ToInt32(System.Console.ReadLine());
 
            var stack = new LinkedList<int>();
            for (var i = 0; i < noCommands; ++i)
            {
                var command = Console.ReadLine();
                var split = command.Split(' ');
 
                if (split[0] == "push")
                {
                    var number = Convert.ToInt32(split[1]);
                    stack.AddFirst(number);
                }
                else if (split[0] == "pop" && stack.Count > 0)
                {
                    stack.RemoveFirst();
                }
                else if (split[0] == "inc")
                {
                    var count = Convert.ToInt32(split[1]);
                    var increment = Convert.ToInt32(split[2]);
                    count = Math.Min(stack.Count, count);
 
                    var node = stack.Last;
                    for (var j = 0; j < count; ++j)
                    {
                        node.Value += increment;
                        node = node.Previous;
                    }
                 }
 
                PrintTop(stack);
            }
        }
 
        static void PrintTop(LinkedList<int> stack)
        {
            if (stack.Count == 0)
            {
                System.Console.WriteLine("EMPTY");
            }
            else
            {
                System.Console.WriteLine("{0}", stack.First.Value);
            }
        }
    }
}
