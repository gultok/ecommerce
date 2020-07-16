using ECommerce.CommandRunner.ParameterObjects;
using System;
using System.Linq;
using System.Net.Http;

namespace ECommerce.CommandRunner.Commands.OrderCommands
{
    public class CreateOrder : ICommand
    {
        public string CommandStr { get; set; }
        private static log4net.ILog Logger;

        public CreateOrder(string commandStr, log4net.ILog logger)
        {
            CommandStr = commandStr;
            Logger = logger;
        }
        public void Run()
        {
            var productCode = CommandStr.Split(' ')[1];
            var quantity = Convert.ToInt32(CommandStr.Split(' ')[2]);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.PostAsJsonAsync(Global.ActionUrl($"/orders"), new OrderParam
            {
                ProductCode = productCode,
                Quantity = quantity
            }).Result;
            string resultMessage = response.Content.ReadAsStringAsync().Result;
            if (!response.IsSuccessStatusCode)
            {
                Logger.Error("Status Code: " + response.StatusCode.ToString() + ", Exception Message: " + resultMessage);
            }
            Console.WriteLine(resultMessage);
        }

        public void Validate()
        {
            if (string.IsNullOrEmpty(CommandStr) || string.IsNullOrWhiteSpace(CommandStr))
                throw new Exception("Command should not be null, space or empty");

            string[] commandAry = CommandStr.Split(' ');

            if (commandAry.Count() < 2)
                throw new Exception("Should be least 1 parameter");
            if (commandAry.Count() > 3)
            {
                int stock;
                if (!Int32.TryParse(commandAry[2], out stock))
                    throw new Exception("Second parameter must be a double");
            }
        }
    }
}