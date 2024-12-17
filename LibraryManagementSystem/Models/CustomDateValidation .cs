using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class CustomDateValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime date)
            {
                return date <= DateTime.Now;
            }
            return false;
        }
    }
}
