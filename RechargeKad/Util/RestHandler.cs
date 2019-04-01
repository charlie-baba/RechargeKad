using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RechargeKad.Util
{
    public class RestHandler
    {
        public static async Task<T> PostJsonAsync<T>(string baseUrl, string path, Object req)
        {
            HttpClient client = new HttpClient();

            try
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                T resp = default(T);
                HttpResponseMessage response = await client.PostAsJsonAsync(path, req);
                resp = await response.Content.ReadAsAsync<T>();

                return resp;
            } finally
            {
                client.Dispose();
            }            
        }
    }
}
