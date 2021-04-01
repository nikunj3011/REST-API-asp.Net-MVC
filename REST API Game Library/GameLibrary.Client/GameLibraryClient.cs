using GameLibrary.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Client
{
    public class GameLibraryClient : IGameLibraryClient
    {
        private string basePath;
        private string baseAddress;

        public GameLibraryClient(string baseAddress)
        {
            this.baseAddress = baseAddress;
            this.basePath = "api/Games";
        }

        public async Task<Games> Get(int? id)
        {
            Games games = null;
            using (var client = new HttpClient() { BaseAddress = new Uri(this.baseAddress) })
            {
                SetupHeaders(client);
                var response = await client.GetAsync(basePath + "/" + id);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    games = JsonConvert.DeserializeObject<Games>(result);
                }
                else
                {
                    //log message
                    throw new Exception("Failed to retrive Game " + id);
                }
            }
            return games;
        }

        public async Task<List<Games>> GetAll()
        {
            List<Games> games = null;
            using (var client = new HttpClient() { BaseAddress = new Uri(this.baseAddress) })
            {
                SetupHeaders(client);
                var response = await client.GetAsync(basePath);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    games = JsonConvert.DeserializeObject<List<Games>>(result);
                }
                else
                {
                    //log message
                    throw new Exception("Failed to retrive Games");
                }
            }
            return games;
        }

        private void SetupHeaders(HttpClient client)
        {
            client.DefaultRequestHeaders.Clear();
            //define request format
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<int> Create(Games games)
        { 
            using (var client = new HttpClient() { BaseAddress = new Uri(this.baseAddress) })
            {
                SetupHeaders(client);
                var json = JsonConvert.SerializeObject(games);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(basePath, stringContent);
                if (response.IsSuccessStatusCode)
                {
                    return 1;
                }
                else
                {
                    //log message
                    throw new Exception("Failed to Create Games");
                }
            }
        }

        public async Task<int> Delete(int id)
        {
            using (var client = new HttpClient() { BaseAddress = new Uri(this.baseAddress) })
            {
                SetupHeaders(client);
                var response = await client.DeleteAsync(basePath + "/" + id);
                if (response.IsSuccessStatusCode)
                {
                    return 1;
                }
                else
                {
                    //log message 
                    throw new Exception("Failed to Delete Game" + id);
                }
            }
        }

        public async Task<int> Delete(Games games)
        {
            using (var client = new HttpClient() { BaseAddress = new Uri(this.baseAddress) })
            {
                SetupHeaders(client);
                var response = await client.DeleteAsync(basePath + "/" + games.GameLibraryID);
                if (response.IsSuccessStatusCode)
                {
                    return 1;
                }
                else
                {
                    //log message 
                    throw new Exception("Failed to Delete Game" + games.GameLibraryID);
                }
            }
        }

        public async Task<int> Update(Games games)
        {
            using (var client = new HttpClient() { BaseAddress = new Uri(this.baseAddress) })
            {
                SetupHeaders(client);
                var json = JsonConvert.SerializeObject(games);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PutAsync(basePath + "/" + games.GameLibraryID, stringContent);
                if (response.IsSuccessStatusCode)
                {
                    return 1;
                }
                else
                {
                    //log message 
                    throw new Exception("Failed to Create Games");
                }
            }
        }

    }
}
