using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GDS.Core.Models.Enums
{
    public enum SystemLogLevel
    {
        [Description("Trace")]
        T = 0,

        [Description("Debug")]
        D = 1,

        [Description("Info")]
        I = 2,

        [Description("Warn")]
        W = 3,

        [Description("Error")]
        E = 4,

        [Description("Fatal")]
        F = 5,

        [Description("Off")]
        O = 6
    }
}