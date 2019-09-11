using System.ComponentModel;

namespace GDS.Reader.Core.Models.Enums
{
    public enum Translations
    {
        [DisplayName("KJV+")]
        [Description("King James Version with strongs")]
        KJV = 0,

        [DisplayName("KJVA")]
        [Description("King James Version with Apochropha")]
        KJVA = 1,

        [DisplayName("KJ'1769")]
        [Description("King James Version (1769)")]
        KJV1769 = 2,

        [DisplayName("AFR")]
        [Description("Afrikaans Ou Vertaaling")]
        AFR = 3,

        [DisplayName("AMP")]
        [Description("Amplified")]
        AMP = 4,

        [DisplayName("AMPC")]
        [Description("Amplified Classic")]
        AMPC = 5,

        [DisplayName("CJB")]
        [Description("Complete Jewish Bible 1998")]
        CJB = 6,
    }
}