using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SimpleRestClient
{
    class Program
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        static async Task Main(string[] args)
        {
            Console.WriteLine("Application Strart");

            try
            {
                var repositories = await ProcessRepositoryAsync();
                foreach (var repository in repositories)
                {
                    Console.WriteLine(repository.Name);
                    Console.WriteLine(repository.Description);
                    Console.WriteLine(repository.GitHubHomeUrl);
                    Console.WriteLine(repository.Homepage);
                    Console.WriteLine(repository.Watchers);
                    Console.WriteLine(repository.LastPush);
                    Console.WriteLine();
                }

            }
            catch (System.Exception e)
            {

                Console.WriteLine(e.Message);
            }


            Console.WriteLine("Application end");
        }

        private static async Task<List<Repository>> ProcessRepositoryAsync()
        {
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json")
            );
            _httpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
            var stringTask = _httpClient.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
            var repositories = await JsonSerializer.DeserializeAsync<List<Repository>>(await stringTask);
            return repositories;

        }
    }
}
