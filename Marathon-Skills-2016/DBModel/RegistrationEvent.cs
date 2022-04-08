namespace Marathon_Skills_2016.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RegistrationEvent")]
    public partial class RegistrationEvent
    {
        public int RegistrationEventId { get; set; }

        public int RegistrationId { get; set; }

        [Required]
        [StringLength(6)]
        public string EventId { get; set; }

        public short? BibNumber { get; set; }

        public int? RaceTime { get; set; }

        public virtual Event Event { get; set; }

        public virtual Registration Registration { get; set; }
    }
}
