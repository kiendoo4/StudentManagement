namespace StudentManagement___IT008.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KQHOCKYTONGHOP")]
    public partial class KQHOCKYTONGHOP
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(7)]
        public string MAHS { get; set; }

        public string HOTEN
        {
            get
            {
                return HOCSINH.HOTENHS;
            }
        }

        [Key]
        [Column(Order = 1)]
        [StringLength(7)]
        public string MAHK { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(7)]
        public string MANH { get; set; }

        [StringLength(7)]
        public string MaHocLuc { get; set; }

        public string tenHL
        {
            get
            {
                return HOCLUC.TenHocLuc;
            }
        }

        [StringLength(7)]
        public string MaHanhKiem { get; set; }

        public string tenHKiem
        {
            get
            {
                return HANHKIEM.TenHanhKiem;
            }
        }
        
        public string STT
        {
            get
            {
                string kq = "";
                int i = 1;
                foreach (KQHOCKYTONGHOP kqh in Entity.ins.KQHOCKYTONGHOPs)
                {
                    if (kqh.MAHK != MAHK) continue;
                    if (kqh.MAHS == MAHS)
                        kq = Convert.ToString(i);
                    else i++;
                }
                return kq;
            }
        }
    public double? DTBTatCaMonHocKy { get; set; }

        public virtual HANHKIEM HANHKIEM { get; set; }

        public virtual HOCKY HOCKY { get; set; }

        public virtual HOCLUC HOCLUC { get; set; }

        public virtual HOCSINH HOCSINH { get; set; }

        public virtual NAMHOC NAMHOC { get; set; }
    }
}
