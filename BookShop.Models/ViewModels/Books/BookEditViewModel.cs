namespace BookShop.Models.ViewModels.Books
{
    /// <summary>
    /// Klasa reprezentująca model wykorzystywany do edycji książki
    /// </summary>
    public class BookEditViewModel : BookPostViewModel
    {
        public int Id { get; set; }
    }
}