using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RedStore_Mvc.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Customer's Name")]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Date Of Birth")]
        public DateTime? BirthDate { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }
        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        [Min18YearForMembership]
        public byte MembershipTypeId { get; set; }


        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo= 1;


    }
}