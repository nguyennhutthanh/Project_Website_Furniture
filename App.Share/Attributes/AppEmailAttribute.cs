using App.Share.Consts;
using System.ComponentModel.DataAnnotations;

namespace App.Share.Attributes
{
    public class AppEmailAttribute : RegularExpressionAttribute
    {
        public AppEmailAttribute(string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$") : base(pattern)
        {
            ErrorMessage = AttributeErrMesg.EMAIL;
        }
    }
}
