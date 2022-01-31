using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Models.Tables
{
    public partial class tbl_station
    {
        public tbl_station()
        {
            tbl_transactions = new HashSet<tbl_transactions>();
        }

        public int RecID { get; set; }
        [Key]
        [StringLength(10)]
        public string StationID { get; set; }
        [Required]
        public string StationName { get; set; }
        [StringLength(10)]
        public string StationNumber { get; set; }
        public bool? IsActive { get; set; }

        [InverseProperty("Station")]
        public virtual ICollection<tbl_transactions> tbl_transactions { get; set; }
    }
}
