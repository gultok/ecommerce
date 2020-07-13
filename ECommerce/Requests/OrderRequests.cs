using ECommerce.ParameterObjects;
using System.Net.Http;
using System.Threading.Tasks;

namespace ECommerce.Requests
{
    public class OrderRequests
    {
        public static async Task<string> CreateOrder(OrderParam order)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsJsonAsync(Global.ActionUrl($"/order/createOrder"), order);
            string resultMessage = "";
            if (response.IsSuccessStatusCode)
            {
                resultMessage = await response.Content.ReadAsStringAsync();
            }
            return resultMessage;
        }
    }
}
