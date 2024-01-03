namespace StudentManagement___IT008.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("MONHOC")]
    public partial class MONHOC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MONHOC()
        {
            DIEMMONHOCs = new HashSet<DIEMMONHOC>();
            DIEMTRUNGBINHMONHOCNAMHOCs = new HashSet<DIEMTRUNGBINHMONHOCNAMHOC>();
            KHANANGGIANGDAYs = new HashSet<KHANANGGIANGDAY>();
            KQHOCKYMONHOCs = new HashSet<KQHOCKYMONHOC>();
            PHANCONGGIANGDAYs = new HashSet<PHANCONGGIANGDAY>();
        }

        [Key]
        [StringLength(7)]
        public string MAMH { get; set; }

        [StringLength(30)]
        public string TENMH { get; set; }

        public bool? ISDELETED { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DIEMMONHOC> DIEMMONHOCs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DIEMTRUNGBINHMONHOCNAMHOC> DIEMTRUNGBINHMONHOCNAMHOCs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KHANANGGIANGDAY> KHANANGGIANGDAYs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KQHOCKYMONHOC> KQHOCKYMONHOCs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHANCONGGIANGDAY> PHANCONGGIANGDAYs { get; set; }
    }
}
