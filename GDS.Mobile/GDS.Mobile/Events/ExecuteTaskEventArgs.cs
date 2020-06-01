using System;
using System.Collections.Generic;
using System.Text;

namespace GDS.Mobile.Events
{
    internal class ExecuteTaskEventArgs : EventArgs
    {
        public bool IsExecuting { get; set; }
        public Exception Exception { get; set; }
        public bool IsSuccess { get; set; }
    }
}