using System;
using System.Threading;

namespace SimpleThread
{
    internal class ThreadWithState
    {
        private string v1;
        private int v2;
        private ExampleCallBack exampleCallBack;

        public ThreadWithState(string v1, int v2, ExampleCallBack exampleCallBack)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.exampleCallBack = exampleCallBack;
        }

        public void Work()
        {
            Console.WriteLine($"{this.v1} : {this.v2}");
            if(exampleCallBack != null)
            {
                exampleCallBack(v2,Thread.CurrentThread.Name);
            }
            Thread.Sleep(TimeSpan.FromSeconds(3));
        }
    }
}