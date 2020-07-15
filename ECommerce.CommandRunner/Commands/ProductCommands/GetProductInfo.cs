using System;
using System.Linq;
using System.Net.Http;

namespace ECommerce.CommandRunner.Commands.ProductCommands
{
    public class GetProductInfo : ICommand
    {
        public string CommandStr { get; set; }
        public GetProductInfo(string commandStr)
        {
            CommandStr = commandStr;
        }

        public void Run()
        {
            var productCode = CommandStr.Split(' ')[1];
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(Global.ActionUrl($"/products/{productCode}")).Result;
            string resultMessage = "";
            if (!response.IsSuccessStatusCode)
            {
                // add log
            }
            resultMessage = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(resultMessage);
        }

        public void Validate()
        {
            if (string.IsNullOrEmpty(CommandStr) || string.IsNullOrWhiteSpace(CommandStr))
                throw new Exception("Command should not be null, space or empty");

            string[] commandAry = CommandStr.Split(' ');

            if (commandAry.Count() < 2)
                throw new Exception("Should be least 1 parameter");
        }
    }
}