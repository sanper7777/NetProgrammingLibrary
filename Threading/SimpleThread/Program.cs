using System;
using System.Threading;

namespace SimpleThread
{
    public delegate void ExampleCallBack(int value, string threadName);
    class Program
    {
        

        static void Main(string[] args)
        {
            Console.WriteLine("Application Start");
            //simple();
            //withParameters();
            //withState();
            //interruptThread();
            interruptWithCancellationToken();
            //interruptWithCancellationToken_2();
            Console.WriteLine("Application End");
            //Console.ReadKey();
        }

        private static void interruptWithCancellationToken_2()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            Console.WriteLine("Press C to send cancellation token to Thread");
            Thread thread_1 = new Thread(() => 
            {
                if(Console.ReadKey().KeyChar.ToString().ToUpperInvariant() == "C")
                {
                    cancellationTokenSource.Cancel();
                }
            });
            Thread thread_2 = new Thread(new ParameterizedThreadStart(Example.DoWorkCancellationToken_2));
            thread_2.Name = "thread_2";
            
            Thread thread_3 = new Thread(new ParameterizedThreadStart(Example.DoWorkCancellationToken_2));
            thread_3.Name = "thread_3";

            thread_1.Start();
            thread_2.Start(cancellationTokenSource.Token);
            thread_3.Start(cancellationTokenSource.Token);
            thread_2.Join();
            thread_3.Join();
            cancellationTokenSource.Dispose();
        }

        private static void interruptWithCancellationToken()
        {
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
           
            ThreadPool.QueueUserWorkItem(new WaitCallback(Example.DoWorkCancellationToken), cancelTokenSource.Token);

            Thread.Sleep(TimeSpan.FromSeconds(2));

            cancelTokenSource.Cancel();
            Console.WriteLine("Cacellation set in token source");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            cancelTokenSource.Dispose();
        }

        static void simple()
        {
            ServerClass serverClass = new ServerClass();

            Thread thread_1 = new Thread(serverClass.IntializeMethod);
            thread_1.Start();

            Thread thread_2 = new Thread(serverClass.StaticMethod);
            thread_2.Start();
        }

        static void withParameters()
        {
            ThreadWithParameters threadWithParameters = new ThreadWithParameters("Parameter passed to thread",42);

            Thread thread = new Thread(new ThreadStart(threadWithParameters.Work));
            thread.Start();
            Console.WriteLine("Waits Another Thread");
            thread.Join();
            Console.WriteLine("Another Thread End");
        }

        static void withState()
        {
            ThreadWithState threadWithState = new ThreadWithState("Parameter passed to thread",55,new ExampleCallBack(ResultCallback));
            Thread thread = new Thread(new ThreadStart(threadWithState.Work));
            thread.Name = "ThreadWithState";
            thread.Start();
            Console.WriteLine("Waits Another Thread");
            thread.Join();
            Console.WriteLine("Another Thread End");
        }

        private static void ResultCallback(int value,string threadName)
        {
            Console.WriteLine($"ResultCallback Thread:{threadName} value:{value}");
        }

        private static void interruptThread()
        {
            Thread sleepingThread = new Thread(Example.SleepIndefinetely);
            sleepingThread.Name = "SleepingThread_1";
            sleepingThread.Start();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            sleepingThread.Interrupt();

            //sleepingThread.Abort(); DEPRECATO
            // sleepingThread = new Thread(Example.SleepIndefinetely); 
            // sleepingThread.Name = "SleepingThread_2";
            // sleepingThread.Start();
            // Thread.Sleep(TimeSpan.FromSeconds(2));
            // sleepingThread.Abort();
        }
    }
}
