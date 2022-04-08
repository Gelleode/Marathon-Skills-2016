namespace Marathon_Skills_2016.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Runner")]
    public partial class Runner
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Runner()
        {
            Registration = new HashSet<Registration>();
        }

        public int RunnerId { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(10)]
        public string Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [Required]
        [StringLength(3)]
        public string CountryCode { get; set; }

        [StringLength(100)]
        public string PhotoPath { get; set; }

        public virtual Country Country { get; set; }

        public virtual Gender Gender1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Registration> Registration { get; set; }

        public virtual User User { get; set; }
    }
}
