using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApp
{
    class thread
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Thead Vs Async/Await");
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            // sử dụng Thread để lập trình bất đồng bộ
            Thread th_one = new Thread(ThreadOne);
            Thread th_two = new Thread(ThreadTwo);

            th_one.Start();
            th_two.Start();

            // Chặn luồng tiếp tục cho tới khi các tiến trình th_one và th_two hoàn thành
            th_one.Join();
            th_two.Join();

            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

            List<int> list = new List<int> { 1, 2, 3, 4, 5 };

            list.ForEach(i =>
            {
                Console.WriteLine("index:" + list.IndexOf(i) + " - value: " + i);
            });

            int result = list[0] + list[1];
            Console.WriteLine(result);

            list.RemoveAt(1);
            list.RemoveAt(0);

            list.ForEach(i =>
            {
                Console.WriteLine("index:" + list.IndexOf(i) + " - value: " + i);
            });


            while (list.Count > 0)
            {
                result += list[0];
                list.RemoveAt(0);
            }

            Console.WriteLine(result);
            list.ForEach(i =>
            {
                Console.WriteLine("index:" + list.IndexOf(i) + " - value: " + i);
            });

            Console.ReadKey();
        }

        private static void ThreadOne()
        {
            Thread.Sleep(5000);
            Console.WriteLine("ThreadOne");
        }

        private static void ThreadTwo()
        {
            Thread.Sleep(2000);
            Console.WriteLine("ThreadTwo");
            Thread.Sleep(1000);
            Console.WriteLine("hi 1s");
        }
    }
}
