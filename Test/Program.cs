﻿using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.ReadKey();
            long a = 2;
            long b = 0;
            MyFunction(a, b, 5);

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
        static void MyFunction(long p1, long p2, long p3)
        {
            long x = p1 + p2 + p3;
            long y = 0;
            y = x / p2;
        }



    }
}
