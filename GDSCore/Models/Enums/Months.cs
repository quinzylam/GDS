using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GDS.Core.Models.Enums
{
    public enum Months
    {
        [Description("Unknown")]
        Unknow = 0,

        [Description("Mar-Apr")]
        Nissan = 1,

        [Description("Apr-May")]
        Iyar = 2,

        [Description("May-Jun")]
        Sivan = 3,

        [Description("Jun-Jul")]
        Tammuz = 4,

        [Description("Jul-Aug")]
        Av = 5,

        [Description("Aug-Sep")]
        Elul = 6,

        [Description("Sep-Oct")]
        Tishrei = 7,

        [Description("Oct-Nov")]
        Cheshvan_Marcheshvan = 8,

        [Description("Nov-Dec")]
        Kislev = 9,

        [Description("Dec-Jan")]
        Tevet = 10,

        [Description("Jan-Feb")]
        Shevat = 11,

        [Description("Feb-Mar")]
        Adar = 12
    }
}