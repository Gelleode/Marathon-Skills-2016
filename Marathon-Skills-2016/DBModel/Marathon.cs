namespace Marathon_Skills_2016.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Marathon")]
    public partial class Marathon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Marathon()
        {
            Event = new HashSet<Event>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte MarathonId { get; set; }

        [Required]
        [StringLength(80)]
        public string MarathonName { get; set; }

        [StringLength(80)]
        public string CityName { get; set; }

        [Required]
        [StringLength(3)]
        public string CountryCode { get; set; }

        public short? YearHeld { get; set; }

        public virtual Country Country { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Event> Event { get; set; }
    }
}
