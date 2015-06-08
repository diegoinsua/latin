using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LatinCMS.Models {
    
    public class UsuarioModel {

        public virtual long Id { get; set; }

        [DisplayName("Rol")]
        public virtual long Rol { get; set; }

        [Required]
        [DisplayName("Nombre")] 
        public virtual string Nombre { get; set; }

        [Required]
        [DisplayName("Apellido")]
        public virtual string Apellido { get; set; }

        [Required]
        [DisplayName("EMail")]
        public virtual string Mail { get; set; }

        [Required]
        [DisplayName("Password")]
        public virtual string Password { get; set; }

        [Required]
        [Compare("Password")]
        [DisplayName("Reingresar Password")]
        public virtual string repass { get; set; }
    }

 }


   
