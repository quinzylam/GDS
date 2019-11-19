using GDS.Core.Models.Administration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Core.Services
{
    public interface ISecurityService<T>
    {
        T User { get; set; }

        Task<bool> LoginAsync(string password);

        Task GetUserAsync(string username);
    }
}