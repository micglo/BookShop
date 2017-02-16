using System.ComponentModel;

namespace BookShop.Data
{
    /// <summary>
    /// Typ wyliczeniowy dla okładki książki
    /// </summary>
    public enum Cover
    {
        [Description("Miękka")]
        SoftCover,

        [Description("Twarda")]
        HardCover,

        [Description("Brak")]
        None
    }
}