namespace StudentManagement___IT008.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GIAOVIEN")]
    public partial class GIAOVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GIAOVIEN()
        {
            KHANANGGIANGDAYs = new HashSet<KHANANGGIANGDAY>();
            LOPHOCTHUCTEs = new HashSet<LOPHOCTHUCTE>();
            PHANCONGGIANGDAYs = new HashSet<PHANCONGGIANGDAY>();
        }

        [Key]
        [StringLength(7)]
        public string MAGV { get; set; }

        [Required]
        [StringLength(100)]
        public string USERNAME { get; set; }

        [StringLength(50)]
        public string HOCVI { get; set; }

        public bool? ISDELETED { get; set; }



        public virtual TAIKHOAN TAIKHOAN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KHANANGGIANGDAY> KHANANGGIANGDAYs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOPHOCTHUCTE> LOPHOCTHUCTEs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHANCONGGIANGDAY> PHANCONGGIANGDAYs { get; set; }
    }
}
