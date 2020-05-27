using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GDS.Core.Models.Enums
{
    public enum BibleVersion
    {
        [Description("King James Version with Apochraphe extended")]
        KJVAE,

        [Description("King James Version with Strongs")]
        KJV,
    }
}