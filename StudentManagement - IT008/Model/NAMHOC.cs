namespace StudentManagement___IT008.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NAMHOC")]
    public partial class NAMHOC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NAMHOC()
        {
            DIEMMONHOCs = new HashSet<DIEMMONHOC>();
            DIEMTRUNGBINHMONHOCNAMHOCs = new HashSet<DIEMTRUNGBINHMONHOCNAMHOC>();
            KQHOCKYMONHOCs = new HashSet<KQHOCKYMONHOC>();
            KQHOCKYTONGHOPs = new HashSet<KQHOCKYTONGHOP>();
            KQNAMHOCs = new HashSet<KQNAMHOC>();
            LOPHOCTHUCTEs = new HashSet<LOPHOCTHUCTE>();
            PHANCONGGIANGDAYs = new HashSet<PHANCONGGIANGDAY>();
        }

        [Key]
        [StringLength(7)]
        public string MANH { get; set; }

        [StringLength(20)]
        public string TENNAMHOC { get; set; }

        public bool? ISDELETED { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DIEMMONHOC> DIEMMONHOCs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DIEMTRUNGBINHMONHOCNAMHOC> DIEMTRUNGBINHMONHOCNAMHOCs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KQHOCKYMONHOC> KQHOCKYMONHOCs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KQHOCKYTONGHOP> KQHOCKYTONGHOPs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KQNAMHOC> KQNAMHOCs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOPHOCTHUCTE> LOPHOCTHUCTEs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHANCONGGIANGDAY> PHANCONGGIANGDAYs { get; set; }
    }
}
