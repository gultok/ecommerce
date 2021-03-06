﻿using System;
using System.Linq;
using System.Net.Http;

namespace ECommerce.CommandRunner.Commands
{
    public class GetCampaignInfo : ICommand
    {
        public string CommandStr { get; set; }
        private static log4net.ILog Logger;

        public GetCampaignInfo(string commandStr, log4net.ILog logger)
        {
            CommandStr = commandStr;
            Logger = logger;
        }
        public void Run()
        {
            var name = CommandStr.Split(' ')[1];
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(Global.ActionUrl($"/campaigns/{name}")).Result;
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
        }
    }
}