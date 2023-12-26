namespace StudentManagement___IT008.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHHS")]
    public partial class PHH
    {
        [Key]
        [StringLength(7)]
        public string MAPHHS { get; set; }

        [StringLength(7)]
        public string MAHS { get; set; }

        [StringLength(100)]
        public string HOTENPHHS { get; set; }

        [StringLength(11)]
        public string SDT { get; set; }

        public virtual HOCSINH HOCSINH { get; set; }
    }
}
