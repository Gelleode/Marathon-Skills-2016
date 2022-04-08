namespace Marathon_Skills_2016.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Registration")]
    public partial class Registration
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Registration()
        {
            RegistrationEvent = new HashSet<RegistrationEvent>();
            Sponsorship = new HashSet<Sponsorship>();
        }

        public int RegistrationId { get; set; }

        public int RunnerId { get; set; }

        public DateTime RegistrationDateTime { get; set; }

        [Required]
        [StringLength(1)]
        public string RaceKitOptionId { get; set; }

        public byte RegistrationStatusId { get; set; }

        public decimal Cost { get; set; }

        public int CharityId { get; set; }

        public decimal SponsorshipTarget { get; set; }

        public virtual Charity Charity { get; set; }

        public virtual RaceKitOption RaceKitOption { get; set; }

        public virtual RegistrationStatus RegistrationStatus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RegistrationEvent> RegistrationEvent { get; set; }

        public virtual Runner Runner { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sponsorship> Sponsorship { get; set; }
    }
}
