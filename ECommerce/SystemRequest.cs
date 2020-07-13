using System.Net.Http;

namespace ECommerce.Requests
{
    public class SystemRequest
    {
        public static string ResetSystemData()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(Global.ActionUrl($"/system/resetData")).Result;
            string resultMessage = "";
            if (response.IsSuccessStatusCode)
            {
                resultMessage = response.Content.ReadAsStringAsync().Result;
            }
            return resultMessage;
        }
        public static string ResetTime()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(Global.ActionUrl($"/time/resetTime")).Result;
            string resultMessage = "";
            if (response.IsSuccessStatusCode)
            {
                resultMessage = response.Content.ReadAsStringAsync().Result;
            }
            return resultMessage;
        }
    }
}
