using System;
using System.Linq;
using System.Net.Http;

namespace ECommerce.CommandRunner.Commands.CommonCommands
{
    public class IncreaseTime : ICommand
    {
        public string CommandStr { get; set; }
        private static log4net.ILog Logger;

        public IncreaseTime(string commandStr, log4net.ILog logger)
        {
            CommandStr = commandStr;
            Logger = logger;
        }
        public void Run()
        {
            int hours = Convert.ToInt16(CommandStr.Split(' ')[1]);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.PostAsync(Global.ActionUrl($"/time/increase-time/{hours}"), null).Result;
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
            int hours;
            if (!Int32.TryParse(commandAry[1], out hours))
                throw new Exception("Parameter must be an int");
        }
    }
}