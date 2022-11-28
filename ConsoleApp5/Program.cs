using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Caculate1
    {
        public async Task CacuExpressResultAsync(double a, double b)
        {
            int n = 58; Console.WriteLine("开始计算，请稍等");
            Task<double> s1calu = Task<double>.Run(() => Power(a, n));
            int m = 28;
            Task<double> s2calu = Task<double>.Run(() => Power(b, m));
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("正在计算，请稍等");
                if (s1calu.Status == TaskStatus.RanToCompletion && s2calu.Status == TaskStatus.RanToCompletion) { break; }
                await Task.Delay(2000);
            }
            double s1 = await s1calu; double s2 = await s2calu;
            Console.WriteLine("计算完毕，结果是：");
            Console.WriteLine(s1 + s2);
        }
        private double Power(double a, int n)
        {
            double s = 1D; Console.WriteLine("-------");
            for (int i = 1; i <= n; i++) { s = s * a; }
            Thread.Sleep(5000); return s;
        }
    }
    class Program
    { 
            static void Main(string[] args) 
            { 
                Caculate1 c = new Caculate1(); 
                c.CacuExpressResultAsync(2.235641, 3.256234852).Wait(); 
                Console.WriteLine("hello world"); 
            } 
        
    }
}
