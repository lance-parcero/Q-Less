using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Models.Tables
{
    public partial class tbl_card_discount_map
    {
        [Key]
        public int RecID { get; set; }
        public int CardTypeID { get; set; }
        [Required]
        [StringLength(10)]
        public string DiscountID { get; set; }

        [ForeignKey(nameof(DiscountID))]
        [InverseProperty(nameof(tbl_discounts.tbl_card_discount_map))]
        public virtual tbl_discounts Discount { get; set; }
    }
}
