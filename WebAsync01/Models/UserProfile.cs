using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace WebAsync01.Models
{
    public class UserProfile
    {
        [Display (Name = "生日")]
        public DateTime? Birthday { get; set; }
    }
}
