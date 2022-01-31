using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Models.Tables
{
    public partial class tbl_passenger
    {
        public tbl_passenger()
        {
            tbl_transactions = new HashSet<tbl_transactions>();
        }

        public long RecID { get; set; }
        [Key]
        [StringLength(16)]
        public string CardNumber { get; set; }
        public int CardTypeID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [StringLength(40)]
        public string ContactNumber { get; set; }
        [StringLength(200)]
        public string EmailAddress { get; set; }
        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }
        public int? ClassificationID { get; set; }
        [Column(TypeName = "decimal(16, 2)")]
        public decimal Balance { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CardExpiry { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedTimestamp { get; set; }
        [StringLength(20)]
        public string SupportingID { get; set; }
        [Required]
        public bool? IsActive { get; set; }

        [ForeignKey(nameof(CardTypeID))]
        [InverseProperty(nameof(tbl_cardtypes.tbl_passenger))]
        public virtual tbl_cardtypes CardType { get; set; }
        [ForeignKey(nameof(ClassificationID))]
        [InverseProperty(nameof(ref_classification.tbl_passenger))]
        public virtual ref_classification Classification { get; set; }
        [InverseProperty("CardNumberNavigation")]
        public virtual ICollection<tbl_transactions> tbl_transactions { get; set; }
    }
}
