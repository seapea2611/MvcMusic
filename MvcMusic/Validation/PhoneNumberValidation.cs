using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MvcMusic.Validation
{
    public class PhoneNumberValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object phoneNumber, ValidationContext validationContext)
        {
            if (phoneNumber == null)
                return ValidationResult.Success;

            string regexStr = @"^(?:(?:\(?(?:00|\+)([1-4]\d\d|[1-9]\d?)\)?)?[\-\.\ \\\/]?)?((?:\(?\d{1,}\)?[\-\.\ \\\/]?){0,})(?:[\-\.\ \\\/]?(?:#|ext\.?|extension|x)[\-\.\ \\\/]?(\d+))?$";

            string phoneNumberStr = ((string)phoneNumber).Trim();
            if (phoneNumberStr.Length > 15)
            {
                return new ValidationResult("Số điện thoại không được vượt quá 15 kí tự.");
            }
            if (Regex.IsMatch(phoneNumberStr, regexStr, RegexOptions.None))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Số điện thoại không hợp lệ.");
            }
        }
    }
}
