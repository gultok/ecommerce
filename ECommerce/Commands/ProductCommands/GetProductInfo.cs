﻿using System;
using System.Linq;
using System.Net.Http;

namespace ECommerce.Commands.ProductCommands
{
    public class GetProductInfo : ICommand
    {
        public string _commandStr { get; set; }
        public GetProductInfo(string commandStr)
        {
            _commandStr = commandStr;
        }

        public void Run()
        {
            var productCode = _commandStr.Split(' ')[1];
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
            if (string.IsNullOrEmpty(_commandStr) || string.IsNullOrWhiteSpace(_commandStr))
                throw new Exception("Command should not be null, space or empty");

            string[] commandAry = _commandStr.Split(' ');
            /*it verifies command has least 1 parameter 
            but it is not sufficient becasue command may not has parameter*/
            if (commandAry.Count() < 2)
                throw new Exception("Should be least 1 parameter");
        }
    }
}