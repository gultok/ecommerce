using ECom;
using ECom.Commands;
using ECommerce.Commands;

namespace ECommerce
{
    public static class CommandConverter
    {
        public static ICommand GetCommand(string commandStr)
        {
            switch (commandStr)
            {
                case string product when product.ToLower().Contains("product")
                    :
                    return new ProductCommand(commandStr);
                case string order when order.ToLower().Contains("order")
                    :
                    return new OrderCommand(commandStr);
                case string campaign when campaign.ToLower().Contains("campaign")
                    :
                    return new CampaignCommand(commandStr);
                case string time when time.ToLower().Contains("time")
                    :
                    return new TimeCommand(commandStr);
                default:
                    return null;
            }
        }

    }
}
