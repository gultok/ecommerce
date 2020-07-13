using ECommerce.ParameterObjects;
using System.Net.Http;
using System.Threading.Tasks;

namespace ECommerce
{
    public class ProductRequests
    {
        public static async Task<string> GetProductAsync(string productCode)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(Global.ActionUrl($"/system/resetData/{productCode}"));
            string resultMessage = "";
            if (response.IsSuccessStatusCode)
            {
                resultMessage = await response.Content.ReadAsStringAsync();
            }
            return resultMessage;
        }
        public static async Task<string> CreateProductAsync(ProductParam product)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsJsonAsync(Global.ActionUrl($"/product/createProduct"), product);
            string resultMessage = "";
            if (response.IsSuccessStatusCode)
            {
                resultMessage = await response.Content.ReadAsStringAsync();
            }
            return resultMessage;
        }
    }
}
