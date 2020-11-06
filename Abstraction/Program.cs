using System;
using System.Collections.Generic;
using System.Reflection;

namespace Abstraction
{
    class Program
    {
        static void Main()
        {
            // StackBoom
            Console.Read();
        }

        static void StackBoom()
        {
            MyStack<string> stack = new MyStack<string>(10);
            stack.Push("m");
            stack.Push("B");
            Console.WriteLine(stack.Pop());
            stack.Push("o");
            stack.Push("o");
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            stack.Pop();
        }
    }

    public class MyStack <T>
    {
        public static int Length;
        public static int Current;
        private static T[] StackBody;

        public MyStack(int length)
        {
            Length = length;
            Current = -1;
            StackBody = new T[length];
        }

        public T Pop()
        {
            if (Current == -1)
            {
                throw new Exception("Stack Underflow");
            }
            else
            {
                T result = StackBody[Current];
                Current--;
                return result;
            }
        }

        public void Push(T input)
        {
            if (Current == Length)
            {
                throw new Exception("Stack Overflow");
            }
            else
            {
                Current++;
                StackBody[Current] = input;
            }
        }
    }
}
