using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Models.Tables
{
    public partial class tbl_routefee_map
    {
        public long RecID { get; set; }
        public int StationIDEntry { get; set; }
        public int StattionIDExit { get; set; }
        [Column(TypeName = "decimal(16, 2)")]
        public decimal Charge { get; set; }
    }
}
