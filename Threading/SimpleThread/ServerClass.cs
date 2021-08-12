using System;
using System.Threading;

namespace SimpleThread
{
    internal class ServerClass
    {
        public ServerClass()
        {
        }

        public void IntializeMethod ()
        {
            Console.WriteLine($"IntializeMethod is runnig on another thread");
            Thread.Sleep(TimeSpan.FromSeconds(3));
            Console.WriteLine($"IntializeMethod end");
        }

        internal void StaticMethod(object obj)
        {
            Console.WriteLine($"StaticMethod is runnig on another thread");
            Thread.Sleep(TimeSpan.FromSeconds(5));
            Console.WriteLine($"StaticMethod end");
        }
    }
}