using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Chap19AsyncCallBackDelegate
{
    class Program
    {
        private static bool isDone = false;

        static void Main(string[] args)
        {
            Console.WriteLine("Main() Invoked on thread: {0}", Thread.CurrentThread.ManagedThreadId);

            Func<int, int, int> myDelegate = Add;
            IAsyncResult iftAR = myDelegate.BeginInvoke(12, 5, new AsyncCallback(AddComplete), null);

            while (!isDone)
            {
                Console.WriteLine("Go Main Go");
                Thread.Sleep(750);
            }

            int result = myDelegate.EndInvoke(iftAR);
            Console.WriteLine("Add Result = {0}", result);

            Console.ReadLine();
        }

        static int Add(int x, int y)
        {
            Console.WriteLine("Add() Invoked on thread: {0}", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(5000);
            return x + y;
        }

        private static void AddComplete(IAsyncResult ar)
        {
            Console.WriteLine("Add is Complete");
            isDone = true;
        }

    }
}
