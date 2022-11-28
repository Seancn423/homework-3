using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Class1 : IMath
    {
        public int add(int a, int b)
        {
            return a + b;
        }

        public int cheng(int a, int b)
        {
            return a - b;
        }

        public int chu(int a, int b)
        {
            return a * b;
        }

        public int jian(int a, int b)
        {
            return a / b;
        }
    }
}
