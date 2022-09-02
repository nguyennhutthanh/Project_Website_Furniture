using App.Share.Consts;
using System.ComponentModel.DataAnnotations;

namespace App.Share.Attributes
{
    public class AppConfirmPwdAttribute : CompareAttribute
    {
        public AppConfirmPwdAttribute(string otherProperty = "Password") : base(otherProperty)
        {
            ErrorMessage = AttributeErrMesg.CONFIRM_PWD;
        }
    }
}
