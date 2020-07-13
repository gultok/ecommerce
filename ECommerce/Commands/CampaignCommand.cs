using ECommerce.Commands;
using ECommerce.ParameterObjects;
using ECommerce.Requests;
using System;
using System.Linq;

namespace ECom.Commands
{
    public class CampaignCommand : ICommand
    {
        public CampaignCommand(string commandStr)
        {
            _commandStr = commandStr;
        }
        public string _commandStr { get; set; }

        public async void Run()
        {
            var commandName = _commandStr.Split(' ')[0];
            var firstParameter = _commandStr.Split(' ')[1];
            string resultMsg = "";
            if (commandName.ToLower().Contains("get"))
                resultMsg = await CampaignRequests.GetCampaignInfo(firstParameter);
            if (commandName.ToLower().Contains("create"))
            {
                var _2ndParam = _commandStr.Split(' ')[2];
                var _3rdParam = Convert.ToInt32(_commandStr.Split(' ')[3]);
                var _4thParam = Convert.ToDouble(_commandStr.Split(' ')[4]);
                var _5thParam = Convert.ToDouble(_commandStr.Split(' ')[5]);
                resultMsg = await CampaignRequests.CreateCampaign(new CampaignParam
                {
                    name = firstParameter,
                    productCode = _2ndParam,
                    duration = _3rdParam,
                    limit = _4thParam,
                    targetSalesCount = _5thParam
                });
            }
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
