using ECommerce.ParameterObjects;
using System;
using System.Linq;
using System.Net.Http;

namespace ECommerce.Commands.OrderCommands
{
    public class CreateOrder : ICommand
    {
        public string _commandStr { get; set; }
        public CreateOrder(string commandStr)
        {
            _commandStr = commandStr;
        }
        public void Run()
        {
            var productCode = _commandStr.Split(' ')[1];
            var quantity = Convert.ToDouble(_commandStr.Split(' ')[2]);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.PostAsJsonAsync(Global.ActionUrl($"/order/createOrder"), new OrderParam
            {
                productCode = productCode,
                quantity = quantity
            }).Result;
            string resultMessage = "";
            if (response.IsSuccessStatusCode)
            {
                resultMessage = response.Content.ReadAsStringAsync().Result;
            }
            Console.WriteLine(resultMessage);
        }

        public void Validate()
        {
            if (string.IsNullOrEmpty(_commandStr) || string.IsNullOrWhiteSpace(_commandStr))
                throw new Exception("Command should not be null, space or empty");

            string[] commandAry = _commandStr.Split(' ');

            /*it verifies command has least 1 parameter 
            but it is not sufficient becasue command may not has parameter*/
            if (commandAry.Count() < 2)
                throw new Exception("Should be least 1 parameter");
            if (commandAry.Count() > 3)
            {
                double stock;
                if (!Double.TryParse(commandAry[2], out stock))
                    throw new Exception("Second parameter must be a double");
            }
        }
    }
}
