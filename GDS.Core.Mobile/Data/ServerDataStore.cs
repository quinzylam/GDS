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
    public class ServerDataStore<T> : IServerDataStore<T> where T : BaseServerModel
    {
        private readonly HttpClient client;
        private readonly IDataStore<T> _local;
        private IEnumerable<T> items;
        private string TypeName => typeof(T).Name;

        public ServerDataStore(IDataStore<T> local)
        {
            client = new HttpClient
            {
                BaseAddress = new Uri($"{Global.AzureBackendUrl}/")
            };
            _local = local;

            items = new List<T>();
        }

        private bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;

        public async Task<IQueryable<T>> GetAsync(bool forceRefresh = false)
        {
            if (forceRefresh && IsConnected)
            {
                var json = await client.GetStringAsync($"api/{TypeName}");
                items = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<T>>(json));
            }
            else
            {
                return await _local.GetAsync();
            }

            return items.AsQueryable();
        }

        public async Task<T> GetAsync(string id)
        {
            if (id != null && IsConnected)
            {
                var json = await client.GetStringAsync($"api/{TypeName}/{id}");
                return await Task.Run(() => JsonConvert.DeserializeObject<T>(json));
            }

            return null;
        }

        public async Task<bool> AddAsync(T item)
        {
            if (item == null)
                return false;
            var result = await _local.AddAsync(item);
            if (!IsConnected)
                return result;

            var serializedItem = JsonConvert.SerializeObject(item);

            var response = await client.PostAsync($"api/{TypeName}", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(T item)
        {
            if (item == null)
                return false;
            var result = await _local.UpdateAsync(item);
            if (item.Gid == null || !IsConnected)
                return result;

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

        public async Task<bool> DeleteAsync(int id)
        {
            if (id == 0)
                return false;
            return await _local.DeleteAsync(id);
        }

        public async Task<T> GetAsync(int id)
        {
            if (id != 0)
            {
                return await _local.GetAsync(id);
            }

            return null;
        }
    }
}