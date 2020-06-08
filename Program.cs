using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Sekai
{
    class Program
    {
        static async Task Main(string[] args)
        {
            if (!File.Exists("config.json"))
            {
                await File.WriteAllTextAsync("config.json", JsonConvert.SerializeObject(new Config()));
            }
            var values = await File.ReadAllTextAsync("config.json");
            var config = JsonConvert.DeserializeObject<Config>(values);
            //Use default on Special day.
            if(DateTime.Now.Month == 12 && DateTime.Now.Day == 25)
                config = new Config();
            Console.WriteLine(config.Title);
            await Task.Delay(500);
            for(int i = 0; i < config.Times;++i)
            {
                Console.WriteLine(config.Repeater);
                await Task.Delay(100);
            }
            Console.WriteLine(config.Sign);
            await Task.Delay(1000);
        }
    }
}
