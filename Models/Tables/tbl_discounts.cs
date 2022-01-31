using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Models.Tables
{
    public partial class tbl_discounts
    {
        public tbl_discounts()
        {
            tbl_card_discount_map = new HashSet<tbl_card_discount_map>();
        }

        public int RecID { get; set; }
        [Key]
        [StringLength(10)]
        public string DiscountID { get; set; }
        [Required]
        [StringLength(50)]
        public string DiscountName { get; set; }
        [Column(TypeName = "decimal(16, 2)")]
        public decimal DiscountValue { get; set; }
        [StringLength(3)]
        public string DiscountType { get; set; }
        [Required]
        public bool? IsActive { get; set; }

        [InverseProperty("Discount")]
        public virtual ICollection<tbl_card_discount_map> tbl_card_discount_map { get; set; }
    }
}
