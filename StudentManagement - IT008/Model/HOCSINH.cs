namespace StudentManagement___IT008.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOCSINH")]
    public partial class HOCSINH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOCSINH()
        {
            DIEMMONHOCs = new HashSet<DIEMMONHOC>();
            DIEMTRUNGBINHMONHOCNAMHOCs = new HashSet<DIEMTRUNGBINHMONHOCNAMHOC>();
            KQHOCKYMONHOCs = new HashSet<KQHOCKYMONHOC>();
            KQHOCKYTONGHOPs = new HashSet<KQHOCKYTONGHOP>();
            KQNAMHOCs = new HashSet<KQNAMHOC>();
            PHHS = new HashSet<PHH>();
            LOPHOCTHUCTEs = new HashSet<LOPHOCTHUCTE>();
        }

        [Key]
        [StringLength(7)]
        public string MAHS { get; set; }

        [StringLength(12)]
        public string CCCD { get; set; }

        [StringLength(100)]
        public string HOTENHS { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? NGSINH { get; set; }

        [StringLength(250)]
        public string EMAIL { get; set; }

        [StringLength(11)]
        public string SDT { get; set; }

        [StringLength(250)]
        public string DCHI { get; set; }

        public bool? GIOITINH { get; set; }

        [StringLength(10)]
        public string TONGIAO { get; set; }

        [StringLength(10)]
        public string DANTOC { get; set; }

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
        public virtual ICollection<PHH> PHHS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOPHOCTHUCTE> LOPHOCTHUCTEs { get; set; }
    }
}
