using ECommerce.ParameterObjects;
using ECommerce.Requests;
using System;
using System.Linq;

namespace ECommerce.Commands
{
    public class CreateCampaign : ICommand
    {
        public string _commandStr { get; set; }
        public CreateCampaign(string commandStr)
        {
            _commandStr = commandStr;
        }
        public async void Run()
        {
            var firstParameter = _commandStr.Split(' ')[1];
            var _2ndParam = _commandStr.Split(' ')[2];
            var _3rdParam = Convert.ToInt32(_commandStr.Split(' ')[3]);
            var _4thParam = Convert.ToDouble(_commandStr.Split(' ')[4]);
            var _5thParam = Convert.ToDouble(_commandStr.Split(' ')[5]);
            string resultMsg = await CampaignRequests.CreateCampaign(new CampaignParam
            {
                name = firstParameter,
                productCode = _2ndParam,
                duration = _3rdParam,
                limit = _4thParam,
                targetSalesCount = _5thParam
            });
            Console.WriteLine(resultMsg);
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
