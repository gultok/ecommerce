using ECommerce.ParameterObjects;
using ECommerce.Requests;
using System;
using System.Linq;

namespace ECommerce.Commands.OrderCommands
{
    public class CreateOrder : ICommand
    {
        public string _commandStr { get; set; }
        public CreateOrder(string commandStr)
        {
            _commandStr = commandStr;
        }
        public async void Run()
        {
            var firstParameter = _commandStr.Split(' ')[1];
            var secondParameter = Convert.ToDouble(_commandStr.Split(' ')[2]);
            string resultMsg = await OrderRequests.CreateOrder(new OrderParam
            {
                productCode = firstParameter,
                quantity = secondParameter
            });
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
                double stock;
                if (!Double.TryParse(commandAry[2], out stock))
                    throw new Exception("Second parameter must be a double");
            }
        }
    }
}
