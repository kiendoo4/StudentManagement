namespace StudentManagement___IT008.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOPHOCTHUCTE")]
    public partial class LOPHOCTHUCTE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOPHOCTHUCTE()
        {
            PHANCONGGIANGDAYs = new HashSet<PHANCONGGIANGDAY>();
            HOCSINHs = new HashSet<HOCSINH>();
        }

        [Key]
        [StringLength(10)]
        public string MALHTT { get; set; }

        [StringLength(7)]
        public string MALOP { get; set; }

        [StringLength(7)]
        public string MANH { get; set; }

        [StringLength(7)]
        public string MAGVCN { get; set; }

        public bool? ISDELETED { get; set; }

        public virtual GIAOVIEN GIAOVIEN { get; set; }

        public virtual LOP LOP { get; set; }

        public virtual NAMHOC NAMHOC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHANCONGGIANGDAY> PHANCONGGIANGDAYs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOCSINH> HOCSINHs { get; set; }
    }
}
