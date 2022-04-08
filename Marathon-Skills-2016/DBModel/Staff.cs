namespace Marathon_Skills_2016.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Staff")]
    public partial class Staff
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Staff()
        {
            Timesheet = new HashSet<Timesheet>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StaffId { get; set; }

        [Required]
        [StringLength(80)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(80)]
        public string LastName { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(10)]
        public string Gender { get; set; }

        public short PositionId { get; set; }

        [StringLength(2000)]
        public string Comments { get; set; }

        public virtual Position Position { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Timesheet> Timesheet { get; set; }
    }
}
