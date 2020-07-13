﻿using System;
using System.Linq;
using System.Net.Http;

namespace ECommerce.Commands
{
    public class GetCampaignInfo : ICommand
    {
        public string _commandStr { get; set; }
        public GetCampaignInfo(string commandStr)
        {
            _commandStr = commandStr;
        }
        public async void Run()
        {
            var name = _commandStr.Split(' ')[1];
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(Global.ActionUrl($"/campaign/getCampaignInfo/{name}"));
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

            /*it verifies command has least 1 parameter 
            but it is not sufficient becasue command may not has parameter*/
            if (commandAry.Count() < 2)
                throw new Exception("Should be least 1 parameter");
        }
    }
}
