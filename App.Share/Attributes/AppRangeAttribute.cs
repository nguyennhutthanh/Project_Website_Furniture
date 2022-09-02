using App.Share.Consts;
using System.ComponentModel.DataAnnotations;

namespace App.Share.Attributes
{
    public class AppRangeAttribute : RangeAttribute
    {
        public AppRangeAttribute(double minimum, double maximum) : base(minimum, maximum)
        {
            ErrorMessage = string.Format(AttributeErrMesg.RANGE, minimum, maximum);
        }
    }
}
