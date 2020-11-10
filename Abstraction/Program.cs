using System;
using System.Collections.Generic;
using System.Reflection;

namespace Abstraction
{
    class Program
    {
        static void Main()
        {
            // StackBoom();
            Console.WriteLine(RPNStackMaths(new object[] { 5, 4, "*", 2, 3, "-", "*" }));
            Console.Read();
        }

        static int RPNStackMaths(object[] equation)
        {
            MyStack<int> stack = new MyStack<int>(equation.Length);
            for(int i = 0; i!=equation.Length; i++)
            {
                if(int.TryParse(equation[i].ToString(), out int c))
                {
                    stack.Push(c);
                }
                else
                {
                    int a = stack.Pop();
                    int b = stack.Pop();
                    if(equation[i].ToString() == "+")
                    {
                        c = a + b;
                    }
                    else if (equation[i].ToString() == "-")
                    {
                        c = a - b;
                    }
                    else if (equation[i].ToString() == "*")
                    {
                        c = a * b;
                    }
                    else if (equation[i].ToString() == "/")
                    {
                        c = a / b;
                    }
                    stack.Push(c);
                }
            }
            if(stack.Pointer() != 0)
            {
                throw new InvalidOperationException("Input is not in RPN format");
            }
            else
            {
                return stack.Pop();
            }
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

        public int Size()
        {
            return Length;
        }

        public int Pointer()
        {
            return Current;
        }
    }
}
