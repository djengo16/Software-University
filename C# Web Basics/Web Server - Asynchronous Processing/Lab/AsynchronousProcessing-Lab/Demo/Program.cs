using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Demo
{
    class Program
    {
        private const string url = "https://en.wikipedia.org/wiki/Nikola_Tesla";
        static async Task Main(string[] args)
        {

            Task.Run(() =>  GetPageLengthAsync());
            Console.WriteLine("Task is processing! Please wait!");

            while (true)
            {
                var read = Console.ReadLine();
                Console.WriteLine(read.ToUpper());
            }

        }

        public static async Task GetPageLengthAsync()
        {
            Stopwatch time = new Stopwatch();
            time.Start();

            HttpClient client = new HttpClient();

            var result = await client.GetByteArrayAsync(url);
                        

            string text = System.Text.Encoding.Default.GetString(result);


            Console.WriteLine(text.Length);
            Console.WriteLine(time.Elapsed);            

        }

    }
}
