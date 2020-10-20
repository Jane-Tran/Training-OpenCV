using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Wrapper
{
    public class Program
    {
        [DllImport("fpga.dll", EntryPoint = "fibonacci_init", CallingConvention = CallingConvention.Cdecl)]
        private static extern void fibonacci_init(long a, long b);

        [DllImport("fpga.dll", EntryPoint = "fibonacci_next", CallingConvention = CallingConvention.Cdecl)]
        private static extern bool fibonacci_next();

        [DllImport("fpga.dll", EntryPoint = "fibonacci_current", CallingConvention = CallingConvention.Cdecl)]
        private static extern long fibonacci_current();

        [DllImport("fpga.dll", EntryPoint = "fibonacci_index", CallingConvention = CallingConvention.Cdecl)]
        private static extern int fibonacci_index();

        public static void Fibonacci_init(long a, long b)
        {
            fibonacci_init(a, b);
        }

        public static bool Fibonacci_next()
        {
            return fibonacci_next();
        }

        public static long Fibonacci_current()
        {
            return fibonacci_current();
        }

        public static int Fibonacci_idex()
        {
            return fibonacci_index();
        }
    }
}
