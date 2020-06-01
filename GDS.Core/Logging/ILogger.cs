using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.Core.Logging
{
    public interface ILogger
    {
        void Trace(string message, string username = null, long? clientId = null, long? warehouseId = null);

        void Debug(Exception ex, string message, string username = null, long? clientId = null, long? warehouseId = null);

        void Information(string message, string username = null, long? clientId = null, long? warehouseId = null);

        void Audit(string username, string message, long? clientId = null, long? warehouseId = null);

        void Warning(string message, Exception ex = null, string username = null, long? clientId = null, long? warehouseId = null);

        void Error(string message, Exception ex = null, string username = null, long? clientId = null, long? warehouseId = null);

        void Fatal(Exception ex, string message, string username = null, long? clientId = null, long? warehouseId = null);
    }
}