using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Models.Tables
{
    public partial class ref_classification
    {
        public ref_classification()
        {
            tbl_passenger = new HashSet<tbl_passenger>();
        }

        public int RecID { get; set; }
        [Key]
        public int ClassificationID { get; set; }
        [Required]
        [StringLength(20)]
        public string ClassificationName { get; set; }
        [Required]
        public bool? IsActive { get; set; }

        [InverseProperty("Classification")]
        public virtual ICollection<tbl_passenger> tbl_passenger { get; set; }
    }
}
