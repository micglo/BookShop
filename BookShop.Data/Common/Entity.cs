namespace BookShop.Data.Common
{
    /// <summary>
    /// Klasa po której dziedziczą encje, aby uzyskać atrybut Id określonego indywidualnie typu wartościowego lub string
    /// </summary>
    /// <typeparam name="T">Typ wartościowy lub string</typeparam>
    public abstract class Entity<T> : BaseEntity
    {
        public virtual T Id { get; set; }
    }
}