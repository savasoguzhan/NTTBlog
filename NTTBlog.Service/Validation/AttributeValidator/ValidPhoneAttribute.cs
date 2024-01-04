using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTBlog.Service.Validation.AttributeValidator
{
    public class ValidPhoneAttribute : ValidationAttribute
    {

        // For Turkish Number
        public override bool IsValid(object? value)
        {
            string phoneNumber = value as string;

            bool isNumeric = phoneNumber.All(char.IsDigit);

            if (isNumeric)
            {
                // To have a valid phone number, it must be at least 10 digits long
                if (phoneNumber.Length >= 10)
                {
                    // If the number is an international number, it should start with a country code, For Turkey it is 90.
                    if (phoneNumber.StartsWith("905"))
                    {
                        // A valid Turkish phone number needs to have 11 digits
                        if (phoneNumber.Length == 12)
                        {
                            return true;
                        }
                    }
                    else if (phoneNumber.StartsWith("05"))
                    {
                        // A valid Turkish phone number needs to have 11 digits
                        if (phoneNumber.Length == 11)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if (phoneNumber.StartsWith("5"))
                        {
                            if (phoneNumber.Length == 10)
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            // Return false if the number is invalid
            ErrorMessage = $"Invalid phone number!";
            return false;
        }

    }
}
