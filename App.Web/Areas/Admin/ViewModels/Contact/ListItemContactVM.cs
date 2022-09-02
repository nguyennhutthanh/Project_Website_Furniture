namespace App.Web.Areas.Admin.ViewModels.Contact
{
    public class ListItemContactVM : ListItemBaseVM
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? Content { get; set; }
    }
}
