namespace StudentManagement___IT008.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Security.Cryptography;

    [Table("TAIKHOAN")]
    public partial class TAIKHOAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TAIKHOAN()
        {
            GIAOVIENs = new HashSet<GIAOVIEN>();
            NHANVIENPHONGDAOTAOs = new HashSet<NHANVIENPHONGDAOTAO>();
        }

        [Key]
        [StringLength(100)]
        public string USERNAME { get; set; }

        [Required]
        [StringLength(100)]
        public string PASSWRD { get; set; }

        [StringLength(7)]
        public string VAITRO { get; set; }

        [Required]
        [StringLength(100)]
        public string HOTEN { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? NGSINH { get; set; }

        [StringLength(50)]
        public string EMAIL { get; set; }

        [StringLength(250)]
        public string DCHI { get; set; }

        public bool? GIOITINH { get; set; }

        public bool? ISDELETED { get; set; }

        public string NGSINHSHOW
        {
            get
            {
                string[] ng = Convert.ToString(NGSINH).Split(' ');
                return ng[0];
            }
        }
        public string GIOITINHSHOW
        {
            get
            {
                string show;
                if (GIOITINH == true)
                    show = "Nam";
                else
                    show = "Nữ";
                return show;
            }
        }
        string hv;
        public string HOCVI
        {
            get
            {
                foreach (GIAOVIEN gv in GIAOVIENs)
                {
                    if (gv.USERNAME == USERNAME)
                    {
                        hv = gv.HOCVI;
                        break;
                    }
                }
                return hv;
            }

        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GIAOVIEN> GIAOVIENs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NHANVIENPHONGDAOTAO> NHANVIENPHONGDAOTAOs { get; set; }
    }
}
