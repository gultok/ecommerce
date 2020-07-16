using ECommerce.CommandRunner.ParameterObjects;
using System;
using System.Linq;
using System.Net.Http;

namespace ECommerce.CommandRunner.Commands
{
    public class CreateCampaign : ICommand
    {
        public string CommandStr { get; set; }
        private static log4net.ILog Logger;

        public CreateCampaign(string commandStr, log4net.ILog logger)
        {
            CommandStr = commandStr;
            Logger = logger;
        }
        public void Run()
        {
            var name = CommandStr.Split(' ')[1];
            var productCode = CommandStr.Split(' ')[2];
            var duration = Convert.ToInt32(CommandStr.Split(' ')[3]);
            var limit = Convert.ToDouble(CommandStr.Split(' ')[4]);
            var targetSalesCount = Convert.ToInt32(CommandStr.Split(' ')[5]);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.PostAsJsonAsync(Global.ActionUrl($"/campaigns"), new CampaignParam
            {
                Name = name,
                ProductCode = productCode,
                Duration = duration,
                Limit = limit,
                TargetSalesCount = targetSalesCount
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

            if (commandAry.Count() > 3)
            {
                int duration;
                if (!Int32.TryParse(commandAry[3], out duration))
                    throw new Exception("Third parameter must be an int");
                decimal limit;
                if (!Decimal.TryParse(commandAry[4], out limit))
                    throw new Exception("Forth parameter must be a decimal");
                int targetSalesCount;
                if (!Int32.TryParse(commandAry[5], out targetSalesCount))
                    throw new Exception("Fiveth parameter must be a double");
            }
        }
    }
}
