using ECommerce;
using ECommerce.Commands;
using ECommerce.ParameterObjects;
using System;
using System.Linq;

namespace ECom
{
    public class ProductCommand : ICommand
    {
        public ProductCommand(string commandStr)
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
                resultMsg = await ProductRequests.GetProductAsync(firstParameter);
            if (commandName.ToLower().Contains("create"))
            {
                var secondParam = Convert.ToDouble(_commandStr.Split(' ')[2]);
                var thirdParam = Convert.ToDouble(_commandStr.Split(' ')[3]);
                resultMsg = await ProductRequests.CreateProductAsync(new ProductParam
                {
                    productcode = firstParameter,
                    price = secondParam,
                    stock = thirdParam
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
                double price;
                if (!Double.TryParse(commandAry[2], out price))
                    throw new Exception("Second parameter must be a decimal");
                double stock;
                if (!Double.TryParse(commandAry[3], out stock))
                    throw new Exception("Third parameter must be a double");
            }
        }
    }
}