namespace StudentManagement___IT008.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHANANGGIANGDAY")]
    public partial class KHANANGGIANGDAY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHANANGGIANGDAY()
        {
            PHANCONGGIANGDAYs = new HashSet<PHANCONGGIANGDAY>();
        }

        [Key]
        [Column(Order = 0)]
        [StringLength(7)]
        public string MAGV { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(7)]
        public string MAMH { get; set; }

        public bool? ISDELETED { get; set; }

        public virtual GIAOVIEN GIAOVIEN { get; set; }

        public virtual MONHOC MONHOC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHANCONGGIANGDAY> PHANCONGGIANGDAYs { get; set; }
    }
}
