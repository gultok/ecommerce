using ECommerce.ParameterObjects;
using System.Net.Http;
using System.Threading.Tasks;

namespace ECommerce.Requests
{
    public class CampaignRequests
    {
        public static async Task<string> GetCampaignInfo(string campaignName)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(Global.ActionUrl($"/campaign/getCampaignInfo/{campaignName}"));
            string resultMessage = "";
            if (response.IsSuccessStatusCode)
            {
                resultMessage = await response.Content.ReadAsStringAsync();
            }
            return resultMessage;
        }
        public static async Task<string> CreateCampaign(CampaignParam campaign)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsJsonAsync(Global.ActionUrl($"/campaign/getProductInfo"), campaign);
            string resultMessage = "";
            if (response.IsSuccessStatusCode)
            {
                resultMessage = await response.Content.ReadAsStringAsync();
            }
            return resultMessage;
        }
    }
}
