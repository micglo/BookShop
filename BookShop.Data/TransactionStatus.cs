using System.ComponentModel;

namespace BookShop.Data
{
    /// <summary>
    /// Typ wyliczeniowy dla statusu transakcji
    /// </summary>
    public enum TransactionStatus
    {
        [Description("Złożona")]
        New,

        [Description("W trakcje realizacji")]
        InProces,

        [Description("Zakończona")]
        Done
    }
}