using System;
using System.Threading;

namespace SimpleThread
{
    internal class Example
    {
        internal static void SleepIndefinetely()
        {
            Console.WriteLine($"Thread{Thread.CurrentThread.Name} about to sleep indefintely");
            try
            {
                Thread.Sleep(Timeout.Infinite);
            }
            catch (ThreadInterruptedException e)
            {
                Console.WriteLine($"Thread{Thread.CurrentThread.Name} awoken\n{e.Message}");
            }
            catch (ThreadAbortException e)
            {
                Console.WriteLine($"Thread{Thread.CurrentThread.Name} aborted\n{e.Message}");
            }
            finally
            {
                Console.WriteLine($"Thread{Thread.CurrentThread.Name} excecuted final block");
            }

            Console.WriteLine($"Thread{Thread.CurrentThread.Name} finish normal execution");
        }

        internal static void DoWorkCancellationToken(object obj)
        {
            CancellationToken cancellationToken = (CancellationToken) obj;

            while(true)
            {
                if(cancellationToken.IsCancellationRequested)
                {
                    Console.WriteLine("Cacnellation token has been requested");

                    // Perform cleanup if necessary.
                    Console.WriteLine("Thread cleanup");
                    // Terminate the operation.
                    break;
                }
                //Simulate work
                Console.WriteLine("Thread work");
                Thread.Sleep(TimeSpan.FromSeconds(2));
            }
        }

        internal static void DoWorkCancellationToken_2(object obj)
        {
            CancellationToken cancellationToken = (CancellationToken)obj;

            while(!cancellationToken.IsCancellationRequested)
            {
                Console.WriteLine($"Thread:{Thread.CurrentThread.Name} Work");
                Thread.Sleep(TimeSpan.FromSeconds(2));
            }
            Console.WriteLine($"Thread:{Thread.CurrentThread.Name} is cancelled");
        }
    }
}