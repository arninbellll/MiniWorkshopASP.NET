using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MiniWS.Models
{
    [Table("cart")]
    public class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        
        [Column("unit_price")]
        [Display(Name = "Price")]
        public decimal UnitPrice { get; set; }
        
        [Column("quantity")]
        [Display(Name = "Quantity")]
        [Range(1, int.MaxValue, ErrorMessage = "The Quantity must be value greater than 0")]
        public int Quantity { get; set; }

        [Column("discount")]
        [Display(Name = "Discount")]
        [Range(0, double.MaxValue, ErrorMessage = "The discount must be value greater than 0")]

        public virtual ICollection<Cart> CartItem { get; set; }
        = new HashSet<Cart>();
        public decimal Total => (decimal)Quantity * UnitPrice;
        public decimal SubTotal => CartItem.Sum(x => x.Total);
        public decimal VatAmount => Math.Round(SubTotal * 0.07m, 2, MidpointRounding.AwayFromZero);
        public decimal NetTotal => SubTotal + VatAmount;

       
    }
}