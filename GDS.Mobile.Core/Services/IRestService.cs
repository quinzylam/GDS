using Simple.OData.Client;
using System;

namespace GDS.Mobile.Core.Services
{
    public interface IRestService
    {
        IODataClient Client { get; }
        Exception Exception { get; }
        bool IsOnline { get; }
    }
}