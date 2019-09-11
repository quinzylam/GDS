using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GDS.Core.Models.Enums
{
    public enum DayOfWeek : int
    {
        [Description("Unknown")]
        Unknow = 0,

        [Description("Sunday")]
        Rishon = 1,

        [Description("Monday")]
        Sheni = 2,

        [Description("Tuesday")]
        Shlishi = 3,

        [Description("Wednesday")]
        Revii = 4,

        [Description("Thursday")]
        Chamishi = 5,

        [Description("Friday")]
        Shishi = 6,

        [Description("Saturday")]
        Shabbat = 7
    }
}