using ECommerce.CommandRunner.Commands;
using ECommerce.CommandRunner.Commands.CommonCommands;
using ECommerce.CommandRunner.Commands.OrderCommands;
using ECommerce.CommandRunner.Commands.ProductCommands;

namespace ECommerce.CommandRunner
{
    public class CommandConverter
    {
        public ICommand GetCommand(string commandStr)
        {
            switch (commandStr)
            {
                case string product when product.ToLower().Contains("product") && product.ToLower().Contains("get"):
                    return new GetProductInfo(commandStr);
                case string product when product.ToLower().Contains("product") && product.ToLower().Contains("create"):
                    return new CreateProduct(commandStr);
                case string order when order.ToLower().Contains("order") && order.ToLower().Contains("create"):
                    return new CreateOrder(commandStr);
                case string campaign when campaign.ToLower().Contains("campaign") && campaign.ToLower().Contains("get"):
                    return new GetCampaignInfo(commandStr);
                case string campaign when campaign.ToLower().Contains("campaign") && campaign.ToLower().Contains("create"):
                    return new CreateCampaign(commandStr);
                case string time when time.ToLower().Contains("time") && time.ToLower().Contains("increase"):
                    return new IncreaseTime(commandStr);
                default:
                    return null;
            }
        }

    }
}