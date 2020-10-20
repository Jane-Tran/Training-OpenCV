using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Cshape_Wrapper;

namespace ConsoleApp
{
    class main
    {
/*        [DllImport("fpga.dll", EntryPoint = "fibonacci_init", CallingConvention = CallingConvention.Cdecl)]
        static extern void fibonacci_init(long a, long b);

        [DllImport("fpga.dll", EntryPoint = "fibonacci_next", CallingConvention = CallingConvention.Cdecl)]
        static extern bool fibonacci_next();

        [DllImport("fpga.dll", EntryPoint = "fibonacci_current", CallingConvention = CallingConvention.Cdecl)]
        static extern long fibonacci_current();

        [DllImport("fpga.dll", EntryPoint = "fibonacci_index", CallingConvention = CallingConvention.Cdecl)]
        static extern int fibonacci_index();*/

        static void Main(string[] args)
        {
            
            Program.Fibonacci_init(1, 1);
            do
            {
                Console.WriteLine(Program.Fibonacci_current());

            } while (Program.Fibonacci_next() && Program.Fibonacci_current() > 0);
            Console.ReadLine();
        }
    }
}
