//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RAHUL_CRUD_NEW.Rahul
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class User_Table
    {
        [Key]
        public int Userid { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required(ErrorMessage ="Do not Match Password")]
        public string Password { get; set; }
        [Required]
        public string MobIle { get; set; }
    }
}
