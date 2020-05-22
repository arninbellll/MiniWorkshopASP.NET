using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MiniWS.Models
{
    [Table("products")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("product_id")]
        [Display(Name = "Product ID")]
        public int ProductId { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "max length 150 charactors")]
        [Column("product_name")]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        //FK
        [Column("supplier_id", Order = 1)]
        [Display(Name = "Supplier Name")]
        public int? SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        [Column("category_Id", Order = 2)]
        [Display(Name = "Category Name")]
        public int? CategoryId { get; set; }
        public Category Category { get; set; }

        [Column("quantity_per_unit")]
        [Display(Name = "Quantity per unit")]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "The Quantity per unit must be at least 1 characters")]
        public string QuantityPerUnit { get; set; }


        [Display(Name = "Price")]
        [Required]
        [Column("unit_price")]
        [DefaultValue(0)]
        [Range(0, int.MaxValue, ErrorMessage = "The Quantity must be more than 0 or equal")]
        public int UnitPrice { get; set; } = 0;

        [Column("units_in_stock")]
        [DefaultValue(0)]
        [Display(Name = "Unit in Stock")]
        public int InStock { get; set; } = 0;

        [Column("units_on_order")]
        [DefaultValue(0)]
        [Display(Name = "Unit On Order")]
        public int OnOrder { get; set; } = 0;


        [Column("reorder_level")]
        [DefaultValue(0)]
        [Display(Name = "ReOrder Level")]
        [Range(0, int.MaxValue, ErrorMessage = "The ReOrder level must be more than 0 or equal")]
        public int ReOrderLevel { get; set; } = 0;

        [Column("photo_product")]
        [Display(Name ="Photo")]
        public string ImagePath  { get; set; }

        [Display(Name = "Discontinued")]

        public int discontinued { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}