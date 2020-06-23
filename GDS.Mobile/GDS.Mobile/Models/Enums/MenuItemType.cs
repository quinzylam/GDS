using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GDS.Mobile.Models.Enums
{
    public enum MenuItemType
    {
        [Description("Read Bible")]
        Read = 0,

        [Description("Library")]
        Library = 1,

        [Description("About")]
        About = 10,

        [Description("Logout")]
        Logout,

        [Description("Exit")]
        Exit = 12,
    }
}