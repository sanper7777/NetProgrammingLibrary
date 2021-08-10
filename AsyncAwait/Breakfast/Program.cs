using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

namespace Breakfast
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wake Up");
            
            var prepareBreakFastTask = PrepareBreakfast();
            var checkMobilePhone = CheckMobilePhone();
            var checkEmail = CheckEmail();
            var checkAddress = CheckAdressWork();

            var wakeUpTasks = new List<Task>
            {
                prepareBreakFastTask,
                checkMobilePhone,
                checkEmail,
                checkAddress
            };
            var completedAllTask = Task.WhenAll(wakeUpTasks);
            completedAllTask.Wait();
            Console.WriteLine(checkAddress.Result);
            //Task.WaitAll(wakeUpTasks.ToArray());
            Console.WriteLine("Go to Work");
            Console.ReadLine();
        }
        
        public static async Task<string> CheckAdressWork()
        {
            Console.WriteLine("Retrive Adress to work");
            await Task.Delay(7000);
            return "Adress: Route 666";
        }
        private static async Task CheckEmail()
        {
            Console.WriteLine("Check Email ");
            await Task.Delay(5000);
            Console.WriteLine("End Email");
        }
        private static async Task CheckMobilePhone()
        {
            Console.WriteLine("Check Mobile Phone");
            await Task.Delay(5000);
            Console.WriteLine("End check Mobile Phone");
            
        }
        private static async Task PrepareBreakfast()
        {
            Coffe cup =  PourCoffee();
            Console.WriteLine("Coffee is ready");

            var eggsTask = FryEggsAsync(2);
            var baconTask = FryBaconAsync(3);
            var toastTask = MakeToastWithButterAndJamAsync(2);

            var breakfastTask = new List<Task>
            {
                eggsTask,
                baconTask,
                toastTask
            };

            while(breakfastTask.Count > 0)
            {
                Task finishedTask = await Task.WhenAny(breakfastTask);
                if(finishedTask == eggsTask)
                {
                    Console.WriteLine("Eggs are ready");
                }
                else if(finishedTask == baconTask)
                {   
                    Console.WriteLine("Bacon bacon is ready");
                }
                else if(finishedTask == toastTask)
                {   
                    Console.WriteLine("toast bacon is ready");
                }
                breakfastTask.Remove(finishedTask);
            }
            
            Juice juice = PourOJ();
            Console.WriteLine("Juice is ready");

            Console.WriteLine("BreakFast is ready");
        }

        private static Juice PourOJ()
        {
            Console.WriteLine("Poring orance juice");
            return new Juice();
        }

        private static void ApplyJam(Toast toast)
        {
            Console.WriteLine("Puttinf jam on the toast...");
        }

        private static void ApplyButter(Toast toast)
        {
            Console.WriteLine("Putting butter on the toast...");
        }

        private static async Task<Toast> ToastBreadAsync(int sliceCount)
        {
            for (int i = 0; i < sliceCount; i++)
            {
                Console.WriteLine("Putting butter on the toast...");
            }
            Console.WriteLine("Start toasting...");
            await Task.Delay(3000);
            Console.WriteLine("Remove toast from toaster...");
            return new Toast();
        }
        private static async Task<Bacon> FryBaconAsync(int sliceCount)
        {
            Console.WriteLine($"Putting {sliceCount} slices of bacon in the pan");
            Console.WriteLine("Coocking first side of bacon...");
            await Task.Delay(3000);
            for (int i = 0; i < sliceCount; i++)
            {
                Console.WriteLine("Flipping a slice of bacon");
            }
            Console.WriteLine("Cooking the second side of bacon");
            await Task.Delay(3000);
            Console.WriteLine("Put bacon on plate");
            return new Bacon();
        }
        private static async Task<Egg> FryEggsAsync(int howMany)
        {
            Console.WriteLine("Warming the egg pan...");
            await Task.Delay(3000);
            Console.WriteLine($"Cracking {howMany} eggs");
            Console.WriteLine("Cooking the eggs ...");
            await Task.Delay(3000);
            Console.WriteLine("Put eggs on plate");
            return new Egg();
        }
        private static Coffe PourCoffee()
        {
            Console.WriteLine("Pouring coffe");
            return new Coffe();
        }

        private static async Task<Toast> MakeToastWithButterAndJamAsync(int howMany)
        {
            var toast = await ToastBreadAsync(howMany);
            ApplyButter(toast);
            ApplyJam(toast);
            return toast;
        }
    }
}
