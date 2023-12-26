namespace StudentManagement___IT008.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHANVIENPHONGDAOTAO")]
    public partial class NHANVIENPHONGDAOTAO
    {
        [Key]
        [StringLength(7)]
        public string MANV { get; set; }

        [Required]
        [StringLength(100)]
        public string USERNAME { get; set; }

        [StringLength(50)]
        public string CHUCVU { get; set; }

        public bool? ISDELETED { get; set; }

        public virtual TAIKHOAN TAIKHOAN { get; set; }
    }
}
