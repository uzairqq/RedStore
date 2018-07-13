using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RedStore_Mvc.Models
{
    public class Min18YearForMembership:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer) validationContext.ObjectInstance;

            if(customer.MembershipTypeId==Customer.Unknown || customer.MembershipTypeId==Customer.PayAsYouGo)
                return ValidationResult.Success;

            if(customer.BirthDate==null)
                return new ValidationResult("Birthdate Is Required");

            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Customer Should be atleast 18 year old to go on a membership");
        }
    }
}