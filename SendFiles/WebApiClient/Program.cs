using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApiClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var file = await DownloadFile();

            File.WriteAllBytes(@"C:\Temp\Example.pdf", file);
        }

        public static async Task<byte[]> DownloadFile()
        {
            using (var client = new HttpClient())
            {
                using (var result = await client.GetAsync("http://localhost:5001/report/v1"))
                {
                    if (result.IsSuccessStatusCode)
                    {
                        return await result.Content.ReadAsByteArrayAsync();
                    }
                }
            }

            return null;
        }
    }
}
