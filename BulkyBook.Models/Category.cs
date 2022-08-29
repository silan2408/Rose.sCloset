
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBook.Models;
public class Category
{
    [Key]
    public int Category_Id { get; set; }
    [Required]
    [Display(Name = "Category Type")]
    public string CategoryName
    {
        get; set;
    }
}