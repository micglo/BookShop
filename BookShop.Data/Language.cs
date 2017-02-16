using System.ComponentModel;

namespace BookShop.Data
{
    /// <summary>
    /// Typ wyleczeniowy dla języka książki
    /// </summary>
    public enum Language
    {
        [Description("Polski")]
        Polish,

        [Description("Angielski")]
        English,

        [Description("Niemiecki")]
        German,

        [Description("Francuski")]
        French,

        [Description("Czeski")]
        Czech
    }
}