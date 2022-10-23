using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using BankApp.Responses;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BankApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KursController : ControllerBase
    {
        [HttpGet("{date}")]
        public async Task<float> GetKurs(DateTime date)
        {
            using (var client = new HttpClient())
            {
                string url = "http://api.nbp.pl";
                string endpoint = "/api/exchangerates/rates/A/USD/";
                string strDate = date.ToString("yyyy-MM-dd");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var WebRequest = new HttpRequestMessage(HttpMethod.Get, url + endpoint + strDate);
                var response = await client.SendAsync(WebRequest);

                if (response.IsSuccessStatusCode)
                {
                    var kursResponse = JsonConvert.DeserializeObject<KursResponse>(response.Content.ReadAsStringAsync().Result);
                    return kursResponse.GetMidKurs();
                }

                return 0;

            }
        }
    }
}

