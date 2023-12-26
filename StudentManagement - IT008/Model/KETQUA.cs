namespace StudentManagement___IT008.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KETQUA")]
    public partial class KETQUA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KETQUA()
        {
            KQNAMHOCs = new HashSet<KQNAMHOC>();
        }

        [Key]
        [StringLength(7)]
        public string MaKetQua { get; set; }

        [Required]
        [StringLength(50)]
        public string TenKetQua { get; set; }

        public bool? ISDELETED { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KQNAMHOC> KQNAMHOCs { get; set; }
    }
}
