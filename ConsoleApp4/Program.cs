using System;
using System.Reflection;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = @":\Users\86132\Desktop\C#程序\ConsoleApp1\ConsoleApp4\bin\Debug\net5.0\ConsoleApp4.dll";
            Assembly asm = Assembly.LoadFrom(filename); 
            Type type = asm.GetType("InterfaceImplement.MyMath"); 
            IMath m = (IMath)Activator.CreateInstance(type); 
            Console.WriteLine(m.add(1, 2).ToString());
        }
    }
}
