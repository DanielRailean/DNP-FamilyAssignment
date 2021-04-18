using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Models;

namespace Data
{
    public class FamilyServiceREST : IFamilyService
    {
        private HttpClient client;
        private string uri = "https://localhost:3001/Family";

        public FamilyServiceREST()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
            {
                return true;
            }; 
            client = new HttpClient(clientHandler);
        }

        public async Task<IList<Family>> GetFamiliesOfUser(int userId)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(uri + $"?userId={@userId}");
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($@"Error: {responseMessage.ReasonPhrase}");
            }

            string result = await responseMessage.Content.ReadAsStringAsync();
            IList<Family> gotFamilies = JsonSerializer.Deserialize<IList<Family>>(result, new JsonSerializerOptions{ PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
            return gotFamilies;
        }

        public Task<IList<Family>> GetAllFamilies()
        {
            throw new NotImplementedException();
        }

        public async Task AddFamily(Family family)
        {
            string familyAsJson = JsonSerializer.Serialize(family);
            HttpContent content = new StringContent(
                familyAsJson,
                Encoding.UTF8,
                "application/json");
            HttpResponseMessage response = await client.PostAsync(uri, content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($@"Error: {response.ReasonPhrase}");
            }
            // Console.WriteLine("post");

        }

        public async Task RemoveFamily(int familyId)
        {
            HttpResponseMessage response =
                await client.DeleteAsync(uri + $"?familyId={@familyId}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($@"Error: {response.ReasonPhrase}");
            }
            // Console.WriteLine("delete");
        }

        public async Task UpdateFamily(Family family)
        {
            string familyAsJson = JsonSerializer.Serialize(family);
            HttpContent content = new StringContent(
                familyAsJson,
                Encoding.UTF8,
                "application/json");
            HttpResponseMessage response = await client.PutAsync(uri, content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($@"Error: {response.ReasonPhrase}");
            }
            // Console.WriteLine("update");
        }
    }
}