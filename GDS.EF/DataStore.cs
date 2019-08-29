using Contracts;
using GDS.Data;
using GDS.Data.EF.Contexts;
using System;

namespace GDS.EF
{
    public partial class DataStore : IDataStore
    {
        private readonly ILoggerManager _logger;
        private readonly GDSContext _ctx;

        public DataStore(ILoggerManager logger)
        {
            _logger = logger;

            //_ctx = new GDSContext();
        }

        public void Dispose()
        {
            if (_ctx != null)
                _ctx.Dispose();
        }
    }
}