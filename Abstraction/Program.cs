using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Abstraction
{
    class Program
    {
        static void Main()
        {
            // StackBoom();
            Console.WriteLine(RPNStackMaths(ShuntingYardAlgorithm(new object[] { 4, "*", 5, "*", "(", 3, "-", 2, ")" })));
            Console.WriteLine(RPNStackMaths(new object[] { 5, 4, "*", 2, 3, "-", "*" }));
            Console.Read();
        }

        static object[] ShuntingYardAlgorithm(object[] infixEquation)
        {
            List<object> output = new List<object> { };
            MyStack<string> operatorStack = new MyStack<string>();
            for(int i = 0; i<infixEquation.Length; i++)
            {
                if (int.TryParse(infixEquation[i].ToString(), out int c))
                {
                    output.Add(infixEquation[i]);
                }
                else
                {
                    if(infixEquation[i].ToString() == "+")
                    {
                        if (operatorStack.IsEmpty())
                        {
                            if(operatorStack.Top().ToString() == "*" || operatorStack.Top().ToString() == "/")
                            {
                                output.Add(operatorStack.Pop());
                            }
                        }
                        operatorStack.Push("+");
                    }
                    else if (infixEquation[i].ToString() == "-")
                    {
                        if (operatorStack.IsEmpty())
                        {
                            if (operatorStack.Top().ToString() == "*" || operatorStack.Top().ToString() == "/")
                            {
                                output.Add(operatorStack.Pop());
                            }
                        }
                        operatorStack.Push("-");
                    }
                    else if (infixEquation[i].ToString() == "*")
                    {
                        operatorStack.Push("*");
                    }
                    else if (infixEquation[i].ToString() == "/")
                    {
                        operatorStack.Push("/");
                    }
                    else if (infixEquation[i].ToString() == "(")
                    {
                        operatorStack.Push("(");
                    }
                    else if (infixEquation[i].ToString() == ")")
                    {
                        while (operatorStack.Top() != "(")
                        {
                            output.Add(operatorStack.Pop());
                        }
                        operatorStack.Pop();
                    }
                }
            }
            while(!operatorStack.IsEmpty())
            {
                output.Add(operatorStack.Pop());
            }
            return output.ToArray();
        }

        static int RPNStackMaths(object[] RPNEquation)
        {
            MyStack<int> stack = new MyStack<int>(RPNEquation.Length);
            for(int i = 0; i!=RPNEquation.Length; i++)
            {
                if(int.TryParse(RPNEquation[i].ToString(), out int c))
                {
                    stack.Push(c);
                }
                else
                {
                    int a = stack.Pop();
                    int b = stack.Pop();
                    if(RPNEquation[i].ToString() == "+")
                    {
                        c = a + b;
                    }
                    else if (RPNEquation[i].ToString() == "-")
                    {
                        c = a - b;
                    }
                    else if (RPNEquation[i].ToString() == "*")
                    {
                        c = a * b;
                    }
                    else if (RPNEquation[i].ToString() == "/")
                    {
                        c = a / b;
                    }
                    stack.Push(c);
                }
            }
            int result = stack.Pop();
            if(! stack.IsEmpty())
            {
                throw new InvalidOperationException("Input is not in RPN format");
            }
            else
            {
                return result;
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

        public MyStack()
        {
            Length = 1000;
            Current = -1;
            StackBody = new T[1000];
        }

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

        public bool IsFull()
        {
            return Current==Length;
        }

        public bool IsEmpty()
        {
            return Current == -1;
        }

        public T Top()
        {
            return StackBody[Current];
        }
    }
}
