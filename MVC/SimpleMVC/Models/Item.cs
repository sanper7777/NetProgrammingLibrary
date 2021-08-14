using System.ComponentModel.DataAnnotations;

namespace SimpleMVC.Models
{
    public class Item
     {
         [Key]
         public int Id { get; set; }
        public string Borrower { get; set; }
        public string Lender { get; set; }
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }
     }
}