using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public int Stock { get; set; }

        [ValidateNever]

        public string Image { get; set; }

        public string size { get; set; }
        public double UnitPrice { get; set; }

        public string ProductName { get; set; }
        public double Discount { get; set; }

        public string Description { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int Category_Id { get; set; }
        [ForeignKey("Category_Id")]
        [ValidateNever]
        public Category Category { get; set; }


        [Display(Name = "Company")]
        public int? Company_Id { get; set; }
        [ValidateNever]
        [ForeignKey("Company_Id")]
        public Company Company { get; set; }

    }
}
