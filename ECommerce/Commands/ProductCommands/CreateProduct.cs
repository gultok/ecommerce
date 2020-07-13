using ECommerce.ParameterObjects;
using System;
using System.Linq;
using System.Net.Http;

namespace ECommerce.Commands.ProductCommands
{
    public class CreateProduct : ICommand
    {
        public string _commandStr { get; set; }
        public CreateProduct(string commandStr)
        {
            _commandStr = commandStr;
        }

        public async void Run()
        {
            var productCode = _commandStr.Split(' ')[1];
            var price = Convert.ToDouble(_commandStr.Split(' ')[2]);
            var stock = Convert.ToDouble(_commandStr.Split(' ')[3]);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsJsonAsync(Global.ActionUrl($"/product/createProduct"), new ProductParam
            {
                productcode = productCode,
                price = price,
                stock = stock
            });
            string resultMessage = "";
            if (response.IsSuccessStatusCode)
            {
                resultMessage = await response.Content.ReadAsStringAsync();
            }
            Console.WriteLine(resultMessage);
        }

        public void Validate()
        {
            if (string.IsNullOrEmpty(_commandStr) || string.IsNullOrWhiteSpace(_commandStr))
                throw new Exception("Command should not be null, space or empty");

            string[] commandAry = _commandStr.Split(' ');

            if (commandAry.Count() > 3)
            {
                double price;
                if (!Double.TryParse(commandAry[2], out price))
                    throw new Exception("Second parameter must be a decimal");
                double stock;
                if (!Double.TryParse(commandAry[3], out stock))
                    throw new Exception("Third parameter must be a double");
            }
        }
    }
}
