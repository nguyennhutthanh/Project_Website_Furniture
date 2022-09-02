using App.Web.WebConfig;
using App.Share.Attributes;

namespace App.Web.ViewModels
{
    public class ContactVM
    {
        [AppRequired]
        public string FullName { get; set; }
        [AppRequired]
        [AppEmail]
        public string Email { get; set; }
        [AppRequired]
        [AppPhone]
        public string PhoneNumber { get; set; }
        public string? Content { get; set; }
    }
}
