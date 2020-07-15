using System;
using System.Linq;
using System.Net.Http;

namespace ECommerce.CommandRunner.Commands.CommonCommands
{
    public class IncreaseTime : ICommand
    {
        public string CommandStr { get; set; }
        public IncreaseTime(string commandStr)
        {
            CommandStr = commandStr;
        }
        public void Run()
        {
            int hours = Convert.ToInt16(CommandStr.Split(' ')[1]);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.PostAsync(Global.ActionUrl($"/time/increase-time/{hours}"), null).Result;
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

            if (commandAry.Count() < 2)
                throw new Exception("Should be least 1 parameter");
            int hours;
            if (!Int32.TryParse(commandAry[1], out hours))
                throw new Exception("Parameter must be an int");
        }
    }
}