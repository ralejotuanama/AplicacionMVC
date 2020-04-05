using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AplicacionMVC.Models
{
    public class Customer
    {

        [Key]
        public int CustomerID { get; set; }


        [StringLength(30, ErrorMessage ="The field {0} must contain {2} between {1} characters" , MinimumLength =3)]
        [Required(ErrorMessage ="you must enter the fiel {0}")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(30,ErrorMessage = "The field {0} must contain {2} between {1} characters",MinimumLength = 3)]
        [Required(ErrorMessage = "you must enter the field {0}")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.PhoneNumber)]
        [StringLength(20, ErrorMessage = "the field {0} must contain {2} between {1} characters" , MinimumLength = 3)]
        [Required(ErrorMessage = "The field {0} is required")]
        public string Phone { get; set; }


        [StringLength(50, ErrorMessage = "the field {0} can contain {2} bettween {1} characters" ,MinimumLength = 3)]
        [Required(ErrorMessage = "The field {0} is required")]
        public string Address{ get; set; }


        [DataType(DataType.EmailAddress)]
        public string email { get; set; }


        [StringLength(30, ErrorMessage = "the field {0} can contain {2} between {1} characters",MinimumLength = 3)]
        [Required(ErrorMessage = "the field {0} is required")]
        public string Document { get; set; }


        public int DocumentTypeID { get; set; }


        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }


        public virtual DocumentType DocumentType { get; set; }

        public virtual ICollection<Order> Orders { get; set; }


    }
}