using App.Share.Consts;
using System.ComponentModel.DataAnnotations;

namespace App.Share.Attributes
{
    public class AppStringLengthAttribute : StringLengthAttribute
    {
        public AppStringLengthAttribute(int minimumLength, int maximumLength) : base(maximumLength)
        {
            MinimumLength = minimumLength;
            ErrorMessage = string.Format(AttributeErrMesg.STRING_LEN, minimumLength, maximumLength);
        }
    }
}
