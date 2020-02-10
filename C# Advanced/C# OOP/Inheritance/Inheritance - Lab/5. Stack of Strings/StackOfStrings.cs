using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public Stack<string> Stack;

        public bool IsEmpty(Stack<string> stack)
        {
            if (!stack.Any())
            {
                return true;
            }
            return false;
        }

        public Stack<string> AddRange(string[] range)
        {
            Stack<string> stack = this.Stack;
            foreach (var current in range)
            {
                this.Stack.Push(current);
            }
            return stack;
        }
    }
}
