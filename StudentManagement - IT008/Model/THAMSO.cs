namespace StudentManagement___IT008.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THAMSO")]
    public partial class THAMSO
    {
        [StringLength(10)]
        public string ID { get; set; }

        [StringLength(100)]
        public string TENTS { get; set; }

        [StringLength(100)]
        public string TYPETS { get; set; }

        [StringLength(1000)]
        public string GIATRI { get; set; }

        [StringLength(1000)]
        public string GHICHU { get; set; }

        public bool? ISDELETED { get; set; }

    }
}
