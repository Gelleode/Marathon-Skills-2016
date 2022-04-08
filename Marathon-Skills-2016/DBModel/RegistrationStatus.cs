namespace Marathon_Skills_2016.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RegistrationStatus
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RegistrationStatus()
        {
            Registration = new HashSet<Registration>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte RegistrationStatusId { get; set; }

        [Column("RegistrationStatus")]
        [Required]
        [StringLength(80)]
        public string RegistrationStatus1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Registration> Registration { get; set; }
    }
}
