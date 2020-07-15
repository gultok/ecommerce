﻿using ECommerce.ParameterObjects;
using System;
using System.Linq;
using System.Net.Http;

namespace ECommerce.Commands.OrderCommands
{
    public class CreateOrder : ICommand
    {
        public string CommandStr { get; set; }
        public CreateOrder(string commandStr)
        {
            CommandStr = commandStr;
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

            /*it verifies command has least 1 parameter 
            but it is not sufficient becasue command may not has parameter*/
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
