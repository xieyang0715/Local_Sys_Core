using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Async.Program
{
    class Program
    {
        static void Main(string[] args)
        {
            var asyncT = GetHtmlAsync();
            while(asyncT.Status != TaskStatus.RanToCompletion)
            {
                Console.WriteLine("wait for the GetHtmlAsync request to complete...,status:{0}", asyncT.Status);
            }
            Console.WriteLine("wait for the GetHtmlAsync request to complete...,status:{0}", asyncT.Status);
            Console.WriteLine("the excute result of GetHtmlAsync method is {0}", asyncT.Result);

            var asyncA = GetFirstCharactersCountAsync(10);
            while (asyncA.Status != TaskStatus.RanToCompletion)
            {
                Console.WriteLine("wait for the GetFirstCharactersCountAsync request to complete...,status:{0}", asyncA.Status);
            }
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }

        private static readonly HttpClient s_client = new HttpClient();

        public static Task<string> GetHtmlAsync()
        {
            // Execution is synchronous here
            var uri = new Uri("https://www.dotnetfoundation.org");
            Console.WriteLine("start GetHtmlAsync:");
            var result = s_client.GetStringAsync(uri);
            Console.WriteLine("get result status GetHtmlAsync:{0}",result.Status);
            return result;
        }

        public static async Task<string> GetFirstCharactersCountAsync(int count)
        {
            // Execution is synchronous here
            var uri = new Uri("https://www.dotnetfoundation.org");

            // Execution of GetFirstCharactersCountAsync() is yielded to the caller here
            // GetStringAsync returns a Task<string>, which is *awaited*
            Console.WriteLine("start GetFirstCharactersCountAsync:");
            var page = await s_client.GetStringAsync(uri);
            Console.WriteLine("get result GetFirstCharactersCountAsync:", page);
            Thread.Sleep(1500);

            // Execution resumes when the client.GetStringAsync task completes,
            // becoming synchronous again.

            if (count > page.Length)
            {
                return page;
            }
            else
            {
                return page.Substring(0, count);
            }
        }
    }
}
