﻿using System;
using System.Linq;

namespace ECommerce.Commands.ProductCommands
{
    public class GetProductInfo : ICommand
    {
        public string _commandStr { get; set; }
        public GetProductInfo(string commandStr)
        {
            _commandStr = commandStr;
        }

        public async void Run()
        {
            var firstParameter = _commandStr.Split(' ')[1];
            string resultMsg = await ProductRequests.GetProductAsync(firstParameter);
            Console.WriteLine(resultMsg);
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
