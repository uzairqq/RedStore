using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RedStore_Mvc.Models;

namespace RedStore_Mvc.Dto
{
    public class NewRentalDto
    {
        public int CustomerId { get; set; }
        public List<int> MovieIds { get; set; }
    }
}