using GDS.Core.Models.Administration;
using GDS.Core.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GDS.Core.Mobile.Services
{
    public class SecurityService : ISecurityService<User>
    {
        private readonly IDataService _dataSevice;

        public SecurityService(IDataService dataService)
        {
            _dataSevice = dataService;
        }

        public User User { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public async Task GetUserAsync(string username)
        {
            User = _dataSevice.Users.Get().FirstOrDefault(x => x.Username == username);
        }

        public Task<bool> LoginAsync(string password)
        {
            throw new NotImplementedException();
        }
    }
}