using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RAHUL_CRUD_NEW.Models
{
    public class StudentModel
    {
        
        public int RollNo { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Class { get; set; }
        [Required]
        public int P_Marks { get; set; }
        [Required]
        public int T_Marks { get; set; }
        [Required]
        public string Add { get; set; }
        [Required]
        public string Mobile { get; set; }
    }
}