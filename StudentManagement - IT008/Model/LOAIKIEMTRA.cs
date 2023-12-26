namespace StudentManagement___IT008.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOAIKIEMTRA")]
    public partial class LOAIKIEMTRA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOAIKIEMTRA()
        {
            DIEMMONHOCs = new HashSet<DIEMMONHOC>();
        }

        [Key]
        [StringLength(7)]
        public string MALKT { get; set; }

        [StringLength(50)]
        public string TENLOAIKIEMTRA { get; set; }

        public double TILE { get; set; }

        public bool? ISDELETED { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DIEMMONHOC> DIEMMONHOCs { get; set; }
    }
}
