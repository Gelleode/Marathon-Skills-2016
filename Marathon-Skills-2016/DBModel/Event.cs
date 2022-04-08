namespace Marathon_Skills_2016.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Event")]
    public partial class Event
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Event()
        {
            RegistrationEvent = new HashSet<RegistrationEvent>();
        }

        [StringLength(6)]
        public string EventId { get; set; }

        [Required]
        [StringLength(50)]
        public string EventName { get; set; }

        [Required]
        [StringLength(2)]
        public string EventTypeId { get; set; }

        public byte MarathonId { get; set; }

        public DateTime? StartDateTime { get; set; }

        public decimal? Cost { get; set; }

        public short? MaxParticipants { get; set; }

        public virtual EventType EventType { get; set; }

        public virtual Marathon Marathon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RegistrationEvent> RegistrationEvent { get; set; }
    }
}
