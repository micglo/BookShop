using BookShop.Data.Common;

namespace BookShop.Data
{
    /// <summary>
    /// Klasa przedstawiająca dokąd ma trafić przesyłka
    /// </summary>
    public class DeliveryAddress : Entity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string PhoneNumber { get; set; }

        public virtual Transaction Transaction { get; set; }
    }
}