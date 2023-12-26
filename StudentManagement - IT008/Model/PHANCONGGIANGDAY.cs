namespace StudentManagement___IT008.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHANCONGGIANGDAY")]
    public partial class PHANCONGGIANGDAY
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(7)]
        public string MANH { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MALHTT { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(7)]
        public string MAGV { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(7)]
        public string MAMH { get; set; }

        public bool? ISDELETED { get; set; }

        public virtual GIAOVIEN GIAOVIEN { get; set; }

        public virtual KHANANGGIANGDAY KHANANGGIANGDAY { get; set; }

        public virtual LOPHOCTHUCTE LOPHOCTHUCTE { get; set; }

        public virtual MONHOC MONHOC { get; set; }

        public virtual NAMHOC NAMHOC { get; set; }
    }
}
