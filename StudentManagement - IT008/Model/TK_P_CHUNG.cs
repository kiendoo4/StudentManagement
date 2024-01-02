using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement___IT008.Model
{
    public partial class TK_P_CHUNG
    {
        
        public TK_P_CHUNG()
        {
            Tk_hs = new List<TK_P_CHITIET>();
        }
        public int STT { get; set; }
        public String Lop { get; set; }
        public int SiSo { get; set; }
        public int SL_Dat { get; set; }
        public string TiLe { get; set; }
        public virtual List<TK_P_CHITIET> Tk_hs { get ; set; }
    }
}
