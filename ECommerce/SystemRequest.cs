using System.Net.Http;
using System.Threading.Tasks;

namespace ECommerce.Requests
{
    public class SystemRequest
    {
        public static async Task<string> ResetSystemData()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(Global.ActionUrl($"/system/resetData"));
            string resultMessage = "";
            if (response.IsSuccessStatusCode)
            {
                resultMessage = await response.Content.ReadAsStringAsync();
            }
            return resultMessage;
        }
        public static async Task<string> ResetTime()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(Global.ActionUrl($"/time/resetTime"));
            string resultMessage = "";
            if (response.IsSuccessStatusCode)
            {
                resultMessage = await response.Content.ReadAsStringAsync();
            }
            return resultMessage;
        }
    }
}
