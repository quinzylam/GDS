using GDS.Core.Logging;
using GDS.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.Mobile.Core.Services
{
    public class Logger : ILogger
    {
        public void Audit(string username, string message, long? clientId = null, long? warehouseId = null)
        {
            FormatMessage(SystemLogLevel.I, $"{username} - {message}");
        }

        public void Debug(Exception ex, string message, string username = null, long? clientId = null, long? warehouseId = null)
        {
            FormatMessage(SystemLogLevel.D, message, ex);
        }

        public void Error(string message, Exception ex = null, string username = null, long? clientId = null, long? warehouseId = null)
        {
            FormatMessage(SystemLogLevel.E, message, ex);
        }

        public void Fatal(Exception ex, string message, string username = null, long? clientId = null, long? warehouseId = null)
        {
            FormatMessage(SystemLogLevel.F, message, ex);
        }

        public void Information(string message, string username = null, long? clientId = null, long? warehouseId = null)
        {
            FormatMessage(SystemLogLevel.I, message);
        }

        public void Trace(string message, string username = null, long? clientId = null, long? warehouseId = null)
        {
            FormatMessage(SystemLogLevel.T, message);
        }

        public void Warning(string message, Exception ex = null, string username = null, long? clientId = null, long? warehouseId = null)
        {
            FormatMessage(SystemLogLevel.W, message, ex);
        }

        private static void FormatMessage(SystemLogLevel type, string message, params object[] args)
        {
            System.Diagnostics.Debug.WriteLine($"\t{type.ToString().ToUpper()}: {DateTime.UtcNow.ToString()} - {message}", args);
        }

        public void HandleError(Exception ex)
        {
            FormatMessage(SystemLogLevel.E, ex.Message, ex);
        }
    }
}