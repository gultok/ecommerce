using ECommerce.ParameterObjects;
using System;
using System.Linq;
using System.Net.Http;

namespace ECommerce.Commands
{
    public class CreateCampaign : ICommand
    {
        public string _commandStr { get; set; }
        public CreateCampaign(string commandStr)
        {
            _commandStr = commandStr;
        }
        public void Run()
        {
            var name = _commandStr.Split(' ')[1];
            var productCode = _commandStr.Split(' ')[2];
            var duration = Convert.ToInt32(_commandStr.Split(' ')[3]);
            var limit = Convert.ToDouble(_commandStr.Split(' ')[4]);
            var targetSalesCount = Convert.ToDouble(_commandStr.Split(' ')[5]);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.PostAsJsonAsync(Global.ActionUrl($"/campaigns"), new CampaignParam
            {
                Name = name,
                ProductCode = productCode,
                Duration = duration,
                Limit = limit,
                TargetSalesCount = targetSalesCount
            }).Result;
            string resultMessage = "";
            if (response.IsSuccessStatusCode)
            {
                resultMessage = response.Content.ReadAsStringAsync().Result;
            }
            Console.WriteLine(resultMessage);
        }

        public void Validate()
        {
            if (string.IsNullOrEmpty(_commandStr) || string.IsNullOrWhiteSpace(_commandStr))
                throw new Exception("Command should not be null, space or empty");

            string[] commandAry = _commandStr.Split(' ');

            //5 parameter verifies???
            if (commandAry.Count() > 3)
            {
                int duration;
                if (!Int32.TryParse(commandAry[3], out duration))
                    throw new Exception("Third parameter must be an int");
                decimal limit;
                if (!Decimal.TryParse(commandAry[4], out limit))
                    throw new Exception("Forth parameter must be a decimal");
                double targetSalesCount;
                if (!Double.TryParse(commandAry[5], out targetSalesCount))
                    throw new Exception("Fiveth parameter must be a double");
            }
        }
    }
}
