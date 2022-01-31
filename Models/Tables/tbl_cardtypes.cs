using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Models.Tables
{
    public partial class tbl_cardtypes
    {
        public tbl_cardtypes()
        {
            tbl_passenger = new HashSet<tbl_passenger>();
        }

        public int RecID { get; set; }
        [Key]
        public int CardTypeID { get; set; }
        [Required]
        public string Name { get; set; }
        public int? Validity { get; set; }
        [Column(TypeName = "decimal(16, 2)")]
        public decimal? BaseRate { get; set; }
        [Column(TypeName = "decimal(16, 2)")]
        public decimal? InitialLoad { get; set; }
        [Required]
        public bool? IsActive { get; set; }

        [InverseProperty("CardType")]
        public virtual ICollection<tbl_passenger> tbl_passenger { get; set; }
    }
}
