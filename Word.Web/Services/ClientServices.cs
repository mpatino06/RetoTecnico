using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Word.Web.Models;

namespace Word.Web.Services
{

    public class ClientServices
    {

        HttpClient client; 
        public string pathUrl = string.Empty;

        public ClientServices()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 25600000;
            client.Timeout = TimeSpan.FromMinutes(2);
        }

        public async Task<List<WordText>> GetCountWord(string pathUrl, string words)
        {
            var items = new List<WordText>();
            string url = pathUrl + "api/WordsCount/" + words;
            try
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<List<WordText>>(content);
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            return items;
        }

        public async Task<List<WordText>> PostCountWord(string pathUrl, string words)
        {
            var items = new List<WordText>();
            try
            {
                string url = pathUrl + "api/WordsCount?";
                string param = $"words={words}";
                HttpContent content = new StringContent(param, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(url + param, content);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode) 
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    items = JsonConvert.DeserializeObject<List<WordText>>(responseBody);

                }

            }
            catch (Exception ex)
            {
                throw;
            }
            return items;
        }

    }
}
