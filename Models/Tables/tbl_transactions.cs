using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Models.Tables
{
    public partial class tbl_transactions
    {
        [Key]
        public long RecID { get; set; }
        [Required]
        [StringLength(16)]
        public string CardNumber { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime TimeOfEntry { get; set; }
        [Required]
        [StringLength(30)]
        public string TypeOfEntry { get; set; }
        [Required]
        [StringLength(10)]
        public string StationID { get; set; }
        [Column(TypeName = "decimal(16, 2)")]
        public decimal CurrentLoad { get; set; }
        [Column(TypeName = "decimal(16, 2)")]
        public decimal? NewLoad { get; set; }
        [Column(TypeName = "decimal(16, 2)")]
        public decimal? Deduction { get; set; }
        [Column(TypeName = "decimal(16, 2)")]
        public decimal? CurrentRate { get; set; }
        [Column(TypeName = "decimal(16, 2)")]
        public decimal? Discount { get; set; }

        [ForeignKey(nameof(CardNumber))]
        [InverseProperty(nameof(tbl_passenger.tbl_transactions))]
        public virtual tbl_passenger CardNumberNavigation { get; set; }
        [ForeignKey(nameof(StationID))]
        [InverseProperty(nameof(tbl_station.tbl_transactions))]
        public virtual tbl_station Station { get; set; }
    }
}
