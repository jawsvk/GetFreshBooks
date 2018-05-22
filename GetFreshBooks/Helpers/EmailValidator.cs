using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace GetFreshBooks.Helpers
{
    public class EmailValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            try
            {
                var emailAddress = new MailAddress((string)value);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}