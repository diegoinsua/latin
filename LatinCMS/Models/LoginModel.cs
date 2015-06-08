using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LatinCMS.Models
{
    public class LoginModel
    {
            [Required]
            [DisplayName("EMail")]
            public virtual string Mail { get; set; }

            [Required]
            [DisplayName("Password")]
            public virtual string Password { get; set; }

        
    }
}