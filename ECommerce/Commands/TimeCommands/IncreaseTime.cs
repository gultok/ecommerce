﻿using ECommerce.Requests;
using System;
using System.Linq;

namespace ECommerce.Commands.CommonCommands
{
    public class IncreaseTime : ICommand
    {
        public string _commandStr { get; set; }
        public IncreaseTime(string commandStr)
        {
            _commandStr = commandStr;
        }
        public async void Run()
        {
            int hours = Convert.ToInt16(_commandStr.Split(' ')[1]);
            string resultMsg = await TimeRequests.IncreaseTime(hours);
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
            int hours;
            if (!Int32.TryParse(commandAry[1], out hours))
                throw new Exception("Parameter must be an int");
        }
    }
}