namespace Marathon_Skills_2016.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Volunteer")]
    public partial class Volunteer
    {
        public int VolunteerId { get; set; }

        [StringLength(80)]
        public string FirstName { get; set; }

        [StringLength(80)]
        public string LastName { get; set; }

        [Required]
        [StringLength(3)]
        public string CountryCode { get; set; }

        [Required]
        [StringLength(10)]
        public string Gender { get; set; }

        public virtual Country Country { get; set; }

        public virtual Gender Gender1 { get; set; }
    }
}
