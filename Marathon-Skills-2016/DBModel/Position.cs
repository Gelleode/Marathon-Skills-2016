namespace Marathon_Skills_2016.DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Position")]
    public partial class Position
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Position()
        {
            Staff = new HashSet<Staff>();
        }

        public short PositionId { get; set; }

        [Required]
        [StringLength(50)]
        public string PositionName { get; set; }

        [StringLength(1000)]
        public string PositionDescription { get; set; }

        [Required]
        [StringLength(10)]
        public string PayPeriod { get; set; }

        public decimal Payrate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Staff> Staff { get; set; }
    }
}
