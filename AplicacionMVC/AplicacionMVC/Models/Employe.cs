using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AplicacionMVC.Models
{
    public class Employe
    {
        [Key]
        public int EmployeId { get; set; }

        [Display(Name ="First Namen")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public decimal Salary { get; set; }

        [Display(Name ="Date Of Birth")]
        [Required(ErrorMessage ="you must enter {0}")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}",ApplyFormatInEditMode =true)]
        public DateTime DateOfBirth { get; set; }

        public int DocumentTypeID { get; set; }

        public virtual DocumentType DocumentType { get; set; }



    }
}