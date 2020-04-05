using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AplicacionMVC.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailID { get; set; }

        public int OrderID { get; set; }

        public int ProductID { get; set; }

        [StringLength(30, ErrorMessage ="the field {0} can contain {2} and {1} characters",MinimumLength =3)]
        [Required(ErrorMessage ="the field {0} is required")]
        [Display(Name = "Product Description")]
        public string Description { get; set; }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "The field {0} is required")]
        [DisplayFormat(DataFormatString = "{0:C2}",ApplyFormatInEditMode = false)]
        public decimal Price { get; set; }


        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "the field {0} is required")]
        [DisplayFormat(DataFormatString = "{0:N2}",ApplyFormatInEditMode = false)]
        public float Quantity { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }


    }
}