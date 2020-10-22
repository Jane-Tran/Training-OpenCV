/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Cshape_Wrapper;
using System.Security.Cryptography.X509Certificates;
using System.Collections;

namespace ConsoleApp
{
    class main
    {
        public static bool flag = true;
        public static List<int> list;
        static void Main(string[] args)
        {

*//*            Program.Fibonacci_init(1, 1);
            do
            {
                Console.WriteLine(Program.Fibonacci_current());

            } while (Program.Fibonacci_next() && Program.Fibonacci_current() > 0);
            Console.ReadLine();*//*

            list = new List<int>();

            Console.WriteLine("Thead Vs Async/Await");

            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            var task_one = TaskOne();
            var task_two = TaskTwo();

            Task.WaitAll(task_one, task_two);
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

            Console.ReadKey();
        }

        private static async Task TaskOne()
        {
            //await Task.Delay(300);
            int i = 0;
            while (flag)
            {
                i++;
                await Task.Delay(300);
                Console.WriteLine("TaskOne run -> " + i);
                list.Add(i);
                *//*list.ForEach(i =>
                {
                    Console.WriteLine("index:" + list.IndexOf(i) + " - value: " + i);
                });*//*

                Console.WriteLine(list[list.Count-1]);
                if (i == 15) break;
            }
        }

        private static async Task TaskTwo()
        {
            *//*await Task.Delay(1000);
            int total = 0;
            Console.WriteLine("TaskTwo -> Total " + total);
            int i = 0;
            while (true)
            {
                await Task.Delay(1);
                total += list[i];
                list.RemoveAt(0);
                if (i == 14) break;
                Console.WriteLine("TaskTwo -> Total " + total);
            }*//*

            while (true)
            {
                await Task.Delay(310);
                list.ForEach(i =>
                {
                    Console.WriteLine("index:" + list.IndexOf(i) + " - value: " + i);
                });
                Console.WriteLine(list.Sum());
            }
            
            *//*await Task.Delay(300);
            Console.WriteLine("hi2");
            await Task.Delay(4400);
            Console.WriteLine("Canel, Total" + list.Sum());
            flag = false;*//*
        }
    }
}
*/