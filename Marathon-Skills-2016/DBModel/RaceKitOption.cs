namespace Marathon_Skills_2016.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RaceKitOption")]
    public partial class RaceKitOption
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RaceKitOption()
        {
            Registration = new HashSet<Registration>();
        }

        [StringLength(1)]
        public string RaceKitOptionId { get; set; }

        [Column("RaceKitOption")]
        [Required]
        [StringLength(80)]
        public string RaceKitOption1 { get; set; }

        public decimal Cost { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Registration> Registration { get; set; }
    }
}
