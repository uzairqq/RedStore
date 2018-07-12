using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RedStore_Mvc.Models;

namespace RedStore_Mvc.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}