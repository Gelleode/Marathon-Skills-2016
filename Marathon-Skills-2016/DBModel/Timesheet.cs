namespace Marathon_Skills_2016.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Timesheet")]
    public partial class Timesheet
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TimeSheetId { get; set; }

        public int StaffId { get; set; }

        public DateTime? StartDateTime { get; set; }

        public DateTime? EndDateTime { get; set; }

        public decimal? PayAmount { get; set; }

        public virtual Staff Staff { get; set; }
    }
}
