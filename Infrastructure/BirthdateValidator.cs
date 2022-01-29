using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MembersRegistration.Infrastructure
{ 
    public class BirthdateValidator: ValidationAttribute
    {
        public BirthdateValidator()
        {
            ErrorMessage = "Please enter a valid birth date.You must be 125 or younger to create";
        }
        public override bool IsValid(object value)
        {
            DateTime enteredDate;
            if (DateTime.TryParse(value.ToString(), out enteredDate))
            {
                if (enteredDate > DateTime.Now.AddYears(-125))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
       

    }
}