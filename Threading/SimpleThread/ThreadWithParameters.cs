using System;
using System.Threading;

namespace SimpleThread
{
    internal class ThreadWithParameters
    {
        private string v1;
        private int v2;

        public ThreadWithParameters(string v1, int v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public void Work()
        {
            Console.WriteLine($"{this.v1} : {this.v2}");
            Thread.Sleep(TimeSpan.FromSeconds(3));
        }
    }
}