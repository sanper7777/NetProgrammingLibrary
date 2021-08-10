using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace HttpRequestCancellationToken
{
    class Program
    {
        static readonly CancellationTokenSource s_cts = new CancellationTokenSource();
        static readonly HttpClient _httpClient = new HttpClient()
        {
             MaxResponseContentBufferSize = 1_000_000
        };

        static readonly IEnumerable<string> urlList = new List<string>
        {
            "https://docs.microsoft.com",
            "https://docs.microsoft.com/aspnet/core",
            "https://docs.microsoft.com/azure",
            "https://docs.microsoft.com/azure/devops",
            "https://docs.microsoft.com/dotnet",
            "https://docs.microsoft.com/dynamics365",
            "https://docs.microsoft.com/education",
            "https://docs.microsoft.com/enterprise-mobility-security",
            "https://docs.microsoft.com/gaming",
            "https://docs.microsoft.com/graph",
            "https://docs.microsoft.com/microsoft-365",
            "https://docs.microsoft.com/office",
            "https://docs.microsoft.com/powershell",
            "https://docs.microsoft.com/sql",
            "https://docs.microsoft.com/surface",
            "https://docs.microsoft.com/system-center",
            "https://docs.microsoft.com/visualstudio",
            "https://docs.microsoft.com/windows",
            "https://docs.microsoft.com/xamarin"
        };

        static async Task Main()
        {
            Console.WriteLine("Application Start");
            Console.WriteLine("Press the Enter key to cancel ...\n");
            try
            {
                // Task cancelTask = Task.Run(()=>
                // {
                //     while (Console.ReadKey().Key != ConsoleKey.Enter)
                //     {
                //         Console.WriteLine("Press the Enter key to cancel...");
                //     }
                //     Console.WriteLine("\nEnter key pressed: cancelling downloads. \n");
                //     s_cts.Cancel();
                    
                // });

                s_cts.CancelAfter(3000);
                await SumPageSizeTask();
                //Task sumPageSizeTask = SumPageSizeTask();
                //await Task.WhenAny(new[]{cancelTask,sumPageSizeTask});
                
            }
            catch (System.Exception e)
            {
                
                Console.WriteLine(e.Message);
            }
            finally
            {
                s_cts.Dispose();
            }
            Console.WriteLine("Application Ending");
        }

        private static async Task SumPageSizeTask()
        {
            var stopwatch = new Stopwatch();
            int total = 0;
            foreach (var url in urlList)
            {
                int contentlength = await ProcessUrlAsync(url,_httpClient,s_cts.Token);
                total += contentlength;
            }
            stopwatch.Stop();
            Console.WriteLine($"Total bytes returned:{total:#.#}");
            Console.WriteLine($"Elapsed time:{stopwatch.Elapsed}");
        }

        private static async Task<int> ProcessUrlAsync(string url, HttpClient httpClient, CancellationToken token)
        {
            HttpResponseMessage responseMessage = await httpClient.GetAsync(url,token);
            byte[] contentlength = await responseMessage.Content.ReadAsByteArrayAsync(token);
            Console.WriteLine($"{url,-60} {contentlength.Length,10:#.#}");
            return contentlength.Length;
        }
    }
}
