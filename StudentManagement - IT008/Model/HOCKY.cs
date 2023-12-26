namespace StudentManagement___IT008.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOCKY")]
    public partial class HOCKY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOCKY()
        {
            DIEMMONHOCs = new HashSet<DIEMMONHOC>();
            KQHOCKYMONHOCs = new HashSet<KQHOCKYMONHOC>();
            KQHOCKYTONGHOPs = new HashSet<KQHOCKYTONGHOP>();
        }

        [Key]
        [StringLength(7)]
        public string MAHK { get; set; }

        [StringLength(20)]
        public string TENHK { get; set; }

        public bool? ISDELETED { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DIEMMONHOC> DIEMMONHOCs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KQHOCKYMONHOC> KQHOCKYMONHOCs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KQHOCKYTONGHOP> KQHOCKYTONGHOPs { get; set; }
    }
}
