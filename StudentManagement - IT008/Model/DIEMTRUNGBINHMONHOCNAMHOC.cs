namespace StudentManagement___IT008.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DIEMTRUNGBINHMONHOCNAMHOC")]
    public partial class DIEMTRUNGBINHMONHOCNAMHOC
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(7)]
        public string MAHS { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(7)]
        public string MANH { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(7)]
        public string MAMH { get; set; }

        public double DTBMonHocNamHoc { get; set; }

        public virtual HOCSINH HOCSINH { get; set; }

        public virtual MONHOC MONHOC { get; set; }

        public virtual NAMHOC NAMHOC { get; set; }
    }
}
