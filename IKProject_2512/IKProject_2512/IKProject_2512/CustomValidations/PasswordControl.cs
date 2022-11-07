using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IKProject_2512.CustomValidations
{
    public class PasswordControl:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value!=null)
            {
                string password = (string)value;
                int counter = 0;
                Regex pass = new Regex(@"[\w]");
                Regex sLetter = new Regex(@"[a-z]");
                Regex cLetter = new Regex(@"[A-Z]");
                Regex number = new Regex(@"[0-9]");
                Regex signs = new Regex(@"[\.]|[\?]|[\\]|[\*]|[\;]|[\,]|[\:]|[-_!']");
                if (pass.IsMatch(password))
                {
                    string combinedPwd = password;
                    char[] combinedPwdArray = combinedPwd.ToCharArray();
                    for (int i = 0; i < combinedPwdArray.Length - 1; i++)
                    {
                        if (sLetter.IsMatch(combinedPwdArray[i].ToString())) { counter++; }
                        if (cLetter.IsMatch(combinedPwdArray[i].ToString())) { counter++; }
                        if (number.IsMatch(combinedPwdArray[i].ToString())) { counter++; }
                        if (signs.IsMatch(combinedPwdArray[i].ToString())) { counter++; }
                    }
                    if (counter < 3)
                    {
                        return new ValidationResult("Yeni Parolanız büyük harf, rakam ve noktalama işareti içermelidir. ");
                    }
                }
                return ValidationResult.Success;
            }
                return ValidationResult.Success;

        }

    }
}
