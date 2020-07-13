using System.Net.Http;
using System.Threading.Tasks;

namespace ECommerce.Requests
{
    public class SystemRequests
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
    }
}
