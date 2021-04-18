using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Models;

namespace Data
{
    public class UserServiceREST : IUserService
    {
        private string uri = "https://localhost:3001/User";
        private User logged;
        private HttpClient client;

        public UserServiceREST()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
            {
                return true;
            }; 
            client = new HttpClient(clientHandler);
        }
        public async Task<User> ValidateUser(string username, string password)
        {

            HttpResponseMessage response =
                await client.GetAsync(uri + $"?username={@username}&password={@password}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($@"Error: {response.ReasonPhrase}");
            }
            string result = await response.Content.ReadAsStringAsync();
            User user = JsonSerializer.Deserialize<User>(result, new JsonSerializerOptions{ PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
            logged = user;
            return user;
        }

        public async Task RegisterUser(User user)
        {
            string UserAsJSON = JsonSerializer.Serialize(user);
            HttpContent content = new StringContent(
                UserAsJSON,
                Encoding.UTF8,
                "application/json");
            HttpResponseMessage response = await client.PostAsync(uri, content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($@"Error: {response.ReasonPhrase}");
            }

            // Console.WriteLine("post");
        }


        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public void RemoveUser(int userId)
        {
            throw new NotImplementedException();

        }

        public int getCurrentUserID()
        {
            if (logged != null)
            {
                return logged.UserId;
            }
            return -1;
        }
    }
}
