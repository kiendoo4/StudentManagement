using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace StudentManagement___IT008.Model
{
    public partial class Entity : DbContext
    {
        public Entity()
            : base("name=Entity")
        {
        }

        public virtual DbSet<DIEMMONHOC> DIEMMONHOCs { get; set; }
        public virtual DbSet<DIEMTRUNGBINHMONHOCNAMHOC> DIEMTRUNGBINHMONHOCNAMHOCs { get; set; }
        public virtual DbSet<GIAOVIEN> GIAOVIENs { get; set; }
        public virtual DbSet<HANHKIEM> HANHKIEMs { get; set; }
        public virtual DbSet<HOCKY> HOCKies { get; set; }
        public virtual DbSet<HOCLUC> HOCLUCs { get; set; }
        public virtual DbSet<HOCSINH> HOCSINHs { get; set; }
        public virtual DbSet<KETQUA> KETQUAs { get; set; }
        public virtual DbSet<KHANANGGIANGDAY> KHANANGGIANGDAYs { get; set; }
        public virtual DbSet<KQHOCKYMONHOC> KQHOCKYMONHOCs { get; set; }
        public virtual DbSet<KQHOCKYTONGHOP> KQHOCKYTONGHOPs { get; set; }
        public virtual DbSet<KQNAMHOC> KQNAMHOCs { get; set; }
        public virtual DbSet<LOAIKIEMTRA> LOAIKIEMTRAs { get; set; }
        public virtual DbSet<LOP> LOPs { get; set; }
        public virtual DbSet<LOPHOCTHUCTE> LOPHOCTHUCTEs { get; set; }
        public virtual DbSet<MONHOC> MONHOCs { get; set; }
        public virtual DbSet<NAMHOC> NAMHOCs { get; set; }
        public virtual DbSet<NHANVIENPHONGDAOTAO> NHANVIENPHONGDAOTAOs { get; set; }
        public virtual DbSet<PHANCONGGIANGDAY> PHANCONGGIANGDAYs { get; set; }
        public virtual DbSet<PHH> PHHS { get; set; }
        public virtual DbSet<TAIKHOAN> TAIKHOANs { get; set; }
        public virtual DbSet<THAMSO> THAMSOes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GIAOVIEN>()
                .HasMany(e => e.KHANANGGIANGDAYs)
                .WithRequired(e => e.GIAOVIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GIAOVIEN>()
                .HasMany(e => e.LOPHOCTHUCTEs)
                .WithOptional(e => e.GIAOVIEN)
                .HasForeignKey(e => e.MAGVCN);

            modelBuilder.Entity<GIAOVIEN>()
                .HasMany(e => e.PHANCONGGIANGDAYs)
                .WithRequired(e => e.GIAOVIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HOCKY>()
                .HasMany(e => e.DIEMMONHOCs)
                .WithRequired(e => e.HOCKY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HOCKY>()
                .HasMany(e => e.KQHOCKYMONHOCs)
                .WithRequired(e => e.HOCKY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HOCKY>()
                .HasMany(e => e.KQHOCKYTONGHOPs)
                .WithRequired(e => e.HOCKY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HOCSINH>()
                .HasMany(e => e.DIEMMONHOCs)
                .WithRequired(e => e.HOCSINH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HOCSINH>()
                .HasMany(e => e.DIEMTRUNGBINHMONHOCNAMHOCs)
                .WithRequired(e => e.HOCSINH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HOCSINH>()
                .HasMany(e => e.KQHOCKYMONHOCs)
                .WithRequired(e => e.HOCSINH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HOCSINH>()
                .HasMany(e => e.KQHOCKYTONGHOPs)
                .WithRequired(e => e.HOCSINH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HOCSINH>()
                .HasMany(e => e.KQNAMHOCs)
                .WithRequired(e => e.HOCSINH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHANANGGIANGDAY>()
                .HasMany(e => e.PHANCONGGIANGDAYs)
                .WithRequired(e => e.KHANANGGIANGDAY)
                .HasForeignKey(e => new { e.MAGV, e.MAMH })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOAIKIEMTRA>()
                .HasMany(e => e.DIEMMONHOCs)
                .WithRequired(e => e.LOAIKIEMTRA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOPHOCTHUCTE>()
                .HasMany(e => e.PHANCONGGIANGDAYs)
                .WithRequired(e => e.LOPHOCTHUCTE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOPHOCTHUCTE>()
                .HasMany(e => e.HOCSINHs)
                .WithMany(e => e.LOPHOCTHUCTEs)
                .Map(m => m.ToTable("LOPHOCTHUCTE_HOCSINH").MapLeftKey("MALHTT").MapRightKey("MAHS"));

            modelBuilder.Entity<MONHOC>()
                .HasMany(e => e.DIEMMONHOCs)
                .WithRequired(e => e.MONHOC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MONHOC>()
                .HasMany(e => e.DIEMTRUNGBINHMONHOCNAMHOCs)
                .WithRequired(e => e.MONHOC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MONHOC>()
                .HasMany(e => e.KHANANGGIANGDAYs)
                .WithRequired(e => e.MONHOC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MONHOC>()
                .HasMany(e => e.KQHOCKYMONHOCs)
                .WithRequired(e => e.MONHOC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MONHOC>()
                .HasMany(e => e.PHANCONGGIANGDAYs)
                .WithRequired(e => e.MONHOC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NAMHOC>()
                .HasMany(e => e.DIEMMONHOCs)
                .WithRequired(e => e.NAMHOC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NAMHOC>()
                .HasMany(e => e.DIEMTRUNGBINHMONHOCNAMHOCs)
                .WithRequired(e => e.NAMHOC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NAMHOC>()
                .HasMany(e => e.KQHOCKYMONHOCs)
                .WithRequired(e => e.NAMHOC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NAMHOC>()
                .HasMany(e => e.KQHOCKYTONGHOPs)
                .WithRequired(e => e.NAMHOC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NAMHOC>()
                .HasMany(e => e.KQNAMHOCs)
                .WithRequired(e => e.NAMHOC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NAMHOC>()
                .HasMany(e => e.PHANCONGGIANGDAYs)
                .WithRequired(e => e.NAMHOC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TAIKHOAN>()
                .HasMany(e => e.GIAOVIENs)
                .WithRequired(e => e.TAIKHOAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TAIKHOAN>()
                .HasMany(e => e.NHANVIENPHONGDAOTAOs)
                .WithRequired(e => e.TAIKHOAN)
                .WillCascadeOnDelete(false);
        }
    }
}
