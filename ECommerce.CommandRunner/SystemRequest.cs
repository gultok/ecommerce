using System.Net.Http;

namespace ECommerce.CommandRunner.Requests
{
    public class SystemRequest
    {
        public static string ResetSystemData()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(Global.ActionUrl($"/system/reset-data")).Result;
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
            HttpResponseMessage response = client.PutAsync(Global.ActionUrl($"/time/reset-time"), null).Result;
            string resultMessage = "";
            if (response.IsSuccessStatusCode)
            {
                resultMessage = response.Content.ReadAsStringAsync().Result;
            }
            return resultMessage;
        }
    }
}