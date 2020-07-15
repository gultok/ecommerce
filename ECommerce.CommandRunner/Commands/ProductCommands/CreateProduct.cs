using ECommerce.CommandRunner.ParameterObjects;
using System;
using System.Linq;
using System.Net.Http;

namespace ECommerce.CommandRunner.Commands.ProductCommands
{
    public class CreateProduct : ICommand
    {
        public string CommandStr { get; set; }
        public CreateProduct(string commandStr)
        {
            CommandStr = commandStr;
        }

        public void Run()
        {
            var productCode = CommandStr.Split(' ')[1];
            var price = Convert.ToDouble(CommandStr.Split(' ')[2]);
            var stock = Convert.ToInt32(CommandStr.Split(' ')[3]);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.PostAsJsonAsync(Global.ActionUrl($"/products"), new ProductParam
            {
                ProductCode = productCode,
                Price = price,
                Stock = stock
            }).Result;
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

            if (commandAry.Count() > 3)
            {
                double price;
                if (!Double.TryParse(commandAry[2], out price))
                    throw new Exception("Second parameter must be a decimal");
                int stock;
                if (!Int32.TryParse(commandAry[3], out stock))
                    throw new Exception("Third parameter must be a double");
            }
        }
    }
}
