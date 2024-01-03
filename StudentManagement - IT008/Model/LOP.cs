namespace StudentManagement___IT008.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("LOP")]
    public partial class LOP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOP()
        {
            LOPHOCTHUCTEs = new HashSet<LOPHOCTHUCTE>();
        }

        [Key]
        [StringLength(7)]
        public string MALOP { get; set; }

        public int KHOI { get; set; }

        [StringLength(30)]
        public string TENLOP { get; set; }
        public string TENLOPSHOW 
        { 
            get
            {
                return "Lớp: " + KHOI + TENLOP;
            }
        }

        public string SISO
        {
            get
            {
                int sl = 0;
                LOPHOCTHUCTE LopHoc = new LOPHOCTHUCTE();
                foreach (LOPHOCTHUCTE lophocfind in LOPHOCTHUCTEs)
                {
                    if(lophocfind.MALOP == MALOP)
                    {
                        LopHoc = lophocfind; break;
                    }
                }
                foreach (HOCSINH lh in LopHoc.HOCSINHs)
                {
                    if(lh.ISDELETED == false) sl++;
                }
                return Convert.ToString(sl);
            }
        }
        public string SISOSHOW
        {
            get
            {
                int sl = 0;
                LOPHOCTHUCTE LopHoc = new LOPHOCTHUCTE();
                foreach (LOPHOCTHUCTE lophocfind in LOPHOCTHUCTEs)
                {
                    if (lophocfind.MALOP == MALOP)
                    {
                        LopHoc = lophocfind; break;
                    }
                }
                foreach (HOCSINH lh in LopHoc.HOCSINHs)
                {
                    if (lh.ISDELETED == false) sl++;
                }
                return "Sỉ số: " + Convert.ToString(sl);
            }
        }
        public string TENGV
        {
            get
            {
                LOPHOCTHUCTE LopHoc = new LOPHOCTHUCTE();
                foreach (LOPHOCTHUCTE lophocfind in LOPHOCTHUCTEs)
                {
                    if (lophocfind.MALOP == MALOP)
                    {
                        LopHoc = lophocfind; break;
                    }
                }
                GIAOVIEN gvcn = new GIAOVIEN();
                foreach (GIAOVIEN gv in Entity.ins.GIAOVIENs)
                {
                    if (gv.MAGV == LopHoc.MAGVCN  && gv.ISDELETED == false)
                    {
                        gvcn = gv; break;
                    }
                }
                if (gvcn != null)
                {
                    TAIKHOAN tk = new TAIKHOAN();
                    foreach (TAIKHOAN alltk in Entity.ins.TAIKHOANs)
                    {
                        if (alltk.USERNAME == gvcn.USERNAME)
                        {
                            tk = alltk; break;
                        }
                    }
                    return tk.HOTEN;
                }
                else
                {
                    return "";
                }    
            }
        }
        public string TENGVSHOW
        {
            get
            {
                LOPHOCTHUCTE LopHoc = new LOPHOCTHUCTE();
                foreach (LOPHOCTHUCTE lophocfind in LOPHOCTHUCTEs)
                {
                    if (lophocfind.MALOP == MALOP)
                    {
                        LopHoc = lophocfind; break;
                    }
                }
                GIAOVIEN gvcn = new GIAOVIEN();
                foreach (GIAOVIEN gv in Entity.ins.GIAOVIENs)
                {
                    if (gv.MAGV == LopHoc.MAGVCN)
                    {
                        gvcn = gv; break;
                    }
                }
                TAIKHOAN tk = new TAIKHOAN();
                foreach (TAIKHOAN alltk in Entity.ins.TAIKHOANs)
                {
                    if (alltk.USERNAME == gvcn.USERNAME)
                    {
                        tk = alltk; break;
                    }
                }
                return "GVCN: " + tk.HOTEN;
            }
        }

        public string NAMHOC
        {
            get
            {
                LOPHOCTHUCTE LopHoc = new LOPHOCTHUCTE();
                foreach (LOPHOCTHUCTE lophocfind in LOPHOCTHUCTEs)
                {
                    if (lophocfind.MALOP == MALOP)
                    {
                        LopHoc = lophocfind; break;
                    }
                }
                NAMHOC mynh = new NAMHOC();
                foreach (NAMHOC nh in Entity.ins.NAMHOCs)
                {
                    if (nh.MANH == LopHoc.MANH)
                    {
                        mynh = nh; break;
                    }
                }
                return mynh.TENNAMHOC;
            }
        }

        public bool? ISDELETED { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOPHOCTHUCTE> LOPHOCTHUCTEs { get; set; }
    }
}
