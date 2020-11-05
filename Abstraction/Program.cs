using System;
using System.Collections.Generic;
using System.Reflection;

namespace Abstraction
{
    class Program
    {
        static int size = 5;
        static string[] stringStack = new string[size];
        static int place = -1;

        static void Main()
        {
            Push("m");
            Push("B");
            Pop();
            Push("o");
            Push("o");
            Pop();
            Pop();
            Pop();
            Pop();
            Console.Read();
        }

        static void Push(string input)
        {
            if (place != size)
            {
                place++;
                stringStack[place] = input;
            }
        }
        
        static void Pop()
        {
            if (place != -1)
            {
                Console.WriteLine(stringStack[place]);
                stringStack[place] = "";
                place--;
            }
            else
            {
                Console.WriteLine("Error: Empty stack");
            }
        }
    }
}
