using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace VirtualVotingSystemDataAccessLayer.Model
{
    public partial class VirtualVotingSystemContext : DbContext
    {
        public VirtualVotingSystemContext()
        {
        }

        public VirtualVotingSystemContext(DbContextOptions<VirtualVotingSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AddressDetail> AddressDetails { get; set; }
        public virtual DbSet<AdminCredential> AdminCredentials { get; set; }
        public virtual DbSet<CandidateDetail> CandidateDetails { get; set; }
        public virtual DbSet<ResultDetail> ResultDetails { get; set; }
        public virtual DbSet<UserDetail> UserDetails { get; set; }
        public virtual DbSet<UserId> UserIds { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=VirtualVotingSystem;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AddressDetail>(entity =>
            {
                entity.HasKey(e => e.AddressId)
                    .HasName("PK__AddressD__091C2AFB77C048EB");

                entity.Property(e => e.ConstituencyState)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DistrictName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.HouseNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StreetName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TownName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AdminCredential>(entity =>
            {
                entity.HasKey(e => e.LoginId)
                    .HasName("PK__AdminCre__4DDA2818287DC59A");

                entity.Property(e => e.LoginId)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CandidateDetail>(entity =>
            {
                entity.HasKey(e => new { e.CandidateId, e.CandidateParty })
                    .HasName("PK__Candidat__E9765867563DB36E");

                entity.HasIndex(e => e.CandidateId, "UQ__Candidat__DF539BFD0ABCDD3E")
                    .IsUnique();

                entity.Property(e => e.CandidateId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CandidateID");

                entity.Property(e => e.CandidateParty)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CandidateName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ConstituencyState)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.AadharNumberNavigation)
                    .WithMany(p => p.CandidateDetails)
                    .HasForeignKey(d => d.AadharNumber)
                    .HasConstraintName("FK__Candidate__Aadha__4222D4EF");
            });

            modelBuilder.Entity<ResultDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ResultDetail");

                entity.Property(e => e.CandidateId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CandidateID");

                entity.Property(e => e.ConstituencyState)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DateofElection).HasColumnType("date");

                entity.Property(e => e.PartyOpted)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Candidate)
                    .WithMany()
                    .HasPrincipalKey(p => p.CandidateId)
                    .HasForeignKey(d => d.CandidateId)
                    .HasConstraintName("FK__ResultDet__Candi__440B1D61");
            });

            modelBuilder.Entity<UserDetail>(entity =>
            {
                entity.HasKey(e => e.AadharNumber)
                    .HasName("PK__UserDeta__5003EE649625DF82");

                entity.Property(e => e.AadharNumber).ValueGeneratedNever();

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.UserDetails)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK__UserDetai__Addre__29572725");
            });

            modelBuilder.Entity<UserId>(entity =>
            {
                entity.HasKey(e => e.Vvid)
                    .HasName("PK__UserId__4C457DD2DA4CD6E3");

                entity.ToTable("UserId");

                entity.HasIndex(e => e.AadharNumber, "UQ__UserId__5003EE65A318C8D1")
                    .IsUnique();

                entity.Property(e => e.Vvid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("VVID");

                entity.Property(e => e.IsCasted).HasDefaultValueSql("((0))");

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.AadharNumberNavigation)
                    .WithOne(p => p.UserId)
                    .HasForeignKey<UserId>(d => d.AadharNumber)
                    .HasConstraintName("FK__UserId__AadharNu__4BAC3F29");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
