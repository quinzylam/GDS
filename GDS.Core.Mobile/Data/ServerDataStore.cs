using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GDS.Core.Data;
using GDS.Core.Models;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace GDS.Core.Mobile.Services
{
    public class ServerDataStore<T> : IServerDataStore<T> where T : IServerModel
    {
        private readonly HttpClient client;
        private IEnumerable<T> items;
        private string TypeName => typeof(T).Name;

        public ServerDataStore()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri($"{Global.AzureBackendUrl}/")
            };

            items = new List<T>();
        }

        private bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;

        public async Task<IEnumerable<T>> GetAsync(bool forceRefresh = false)
        {
            if (forceRefresh && IsConnected)
            {
                var json = await client.GetStringAsync($"api/{TypeName}");
                items = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<T>>(json));
            }
            return items;
        }

        public async Task<T> GetAsync(string id)
        {
            if (id != null && IsConnected)
            {
                var json = await client.GetStringAsync($"api/{TypeName}/{id}");
                return await Task.Run(() => JsonConvert.DeserializeObject<T>(json));
            }

            return default;
        }

        public async Task<bool> AddAsync(T item)
        {
            if (item == null || !IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(item);

            var response = await client.PostAsync($"api/{TypeName}", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(T item)
        {
            if (item == null || item?.Gid == null || !IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(item);
            var buffer = Encoding.UTF8.GetBytes(serializedItem);
            var byteContent = new ByteArrayContent(buffer);

            var response = await client.PutAsync(new Uri($"api/{TypeName}/{item.Gid}"), byteContent);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            if (string.IsNullOrEmpty(id) && !IsConnected)
                return false;

            var response = await client.DeleteAsync($"api/{TypeName}/{id}");

            return response.IsSuccessStatusCode;
        }

        public IQueryable<T> Get()
        {
            if (IsConnected)
            {
                var json = Task.Run(async () => await client.GetStringAsync($"api/{TypeName}")).Result;
                items = JsonConvert.DeserializeObject<IEnumerable<T>>(json);
            }
            return items.AsQueryable();
        }

        public T Get(int id)
        {
            if (id != 0 && IsConnected)
            {
                var json = Task.Run(async () => await client.GetStringAsync($"api/{TypeName}/{id}")).Result;
                return JsonConvert.DeserializeObject<T>(json);
            }

            return default;
        }
    }
}