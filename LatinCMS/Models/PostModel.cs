using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LatinCMS.Models
{
    public class PostModel
    {
        public virtual long Id { get; set; }
        public virtual long Usuario { get; set; }
        public virtual int TipoPost { get; set; }
    }
}