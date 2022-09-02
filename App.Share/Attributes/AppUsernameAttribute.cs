using App.Share.Consts;
using System.ComponentModel.DataAnnotations;

namespace App.Share.Attributes
{
    public class AppUsernameAttribute : RegularExpressionAttribute
    {
        public AppUsernameAttribute(string pattern = @"^(?!.*[_.]{2})[a-zA-Z0-9._]+$") : base(pattern)
        {
            ErrorMessage = AttributeErrMesg.USERNAME;

            /*
			^(?!.*[_.]{2})[a-zA-Z0-9._]+$
			 └─────┬─────┘└─────┬─────┘
				   │            chỉ chấp nhận chữ thường, chữ hoa, số và _.
				   |
				   chông chấp nhận __ hoặc .. hoặc _. hoặc ._
			*/
        }
    }
}
