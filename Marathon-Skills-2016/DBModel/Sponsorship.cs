namespace Marathon_Skills_2016.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sponsorship")]
    public partial class Sponsorship
    {
        public int SponsorshipId { get; set; }

        [Required]
        [StringLength(150)]
        public string SponsorName { get; set; }

        public int RegistrationId { get; set; }

        public decimal Amount { get; set; }

        public virtual Registration Registration { get; set; }
    }
}
