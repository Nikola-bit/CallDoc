using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CallDoc.API.Models
{
    public partial class CallDocContext : DbContext
    {
        public CallDocContext()
        {
        }

        public CallDocContext(DbContextOptions<CallDocContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Appointment> Appointment { get; set; }
        public virtual DbSet<CreditCard> CreditCard { get; set; }
        public virtual DbSet<DoctorSubSpecialties> DoctorSubSpecialties { get; set; }
        public virtual DbSet<Institution> Institution { get; set; }
        public virtual DbSet<InstitutionBranch> InstitutionBranch { get; set; }
        public virtual DbSet<InstitutionDoctors> InstitutionDoctors { get; set; }
        public virtual DbSet<InstitutionServices> InstitutionServices { get; set; }
        public virtual DbSet<InstitutionSpecialties> InstitutionSpecialties { get; set; }
        public virtual DbSet<InstitutionSubSpecialties> InstitutionSubSpecialties { get; set; }
        public virtual DbSet<Member> Member { get; set; }
        public virtual DbSet<MemberDetails> MemberDetails { get; set; }
        public virtual DbSet<MemberInvitation> MemberInvitation { get; set; }
        public virtual DbSet<PatientHistory> PatientHistory { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<PlatformConfiguration> PlatformConfiguration { get; set; }
        public virtual DbSet<PlatformService> PlatformService { get; set; }
        public virtual DbSet<PlatformSpecialty> PlatformSpecialty { get; set; }
        public virtual DbSet<PlatformSubSpecialty> PlatformSubSpecialty { get; set; }
        public virtual DbSet<Service> Service { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=185.165.211.48;Database=CallDoc_Dev;User Id=calldoc_sql;Password=DmqWg87TEQYbELz7;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.PostCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.StreetName)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.Property(e => e.AppointemtsDate).HasColumnType("datetime");

                entity.Property(e => e.CancellationReasonNote).HasMaxLength(500);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TransactionCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.CancellationBy)
                    .WithMany(p => p.AppointmentCancellationBy)
                    .HasForeignKey(d => d.CancellationById)
                    .HasConstraintName("FK_Appointment_CancellationBy");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.AppointmentDoctor)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Appointment_Doctor");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.AppointmentPatient)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Appointment_Patient");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Appointment)
                    .HasForeignKey(d => d.PaymentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Appointment_Payment");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Appointment)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Appointment_Service");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Appointment)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Appointment_Status");
            });

            modelBuilder.Entity<CreditCard>(entity =>
            {
                entity.Property(e => e.ExpiryDate).HasColumnType("date");

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.CreditCard)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CreditCard_Member");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.CreditCard)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CreditCard_Type");
            });

            modelBuilder.Entity<DoctorSubSpecialties>(entity =>
            {
                entity.HasKey(e => e.DoctorSubSpecialties1);

                entity.Property(e => e.DoctorSubSpecialties1).HasColumnName("DoctorSubSpecialties");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.DoctorSubSpecialties)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DoctorSubSpecialties_Doctor");

                entity.HasOne(d => d.SubSpecialty)
                    .WithMany(p => p.DoctorSubSpecialties)
                    .HasForeignKey(d => d.SubSpecialtyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DoctorSubSpecialties_SubSpecialty");
            });

            modelBuilder.Entity<Institution>(entity =>
            {
                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Logo).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.InstitutionStatus)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Institution_Status");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.InstitutionType)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Institution_Type");
            });

            modelBuilder.Entity<InstitutionBranch>(entity =>
            {
                entity.Property(e => e.Biography).HasMaxLength(250);

                entity.Property(e => e.ContactEmail).HasMaxLength(50);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Logo).HasMaxLength(80);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.Website).HasMaxLength(80);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.InstitutionBranch)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InstitutionBranch_Address");

                entity.HasOne(d => d.Institution)
                    .WithMany(p => p.InstitutionBranch)
                    .HasForeignKey(d => d.InstitutionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InstitutionBranch_Institution");
            });

            modelBuilder.Entity<InstitutionDoctors>(entity =>
            {
                entity.HasKey(e => e.InstitutionDoctorId);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.InstitutionDoctors)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InstitutionDoctors_Doctor");

                entity.HasOne(d => d.InstitutionBranch)
                    .WithMany(p => p.InstitutionDoctors)
                    .HasForeignKey(d => d.InstitutionBranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InstitutionDoctors_InstitutionBranch");
            });

            modelBuilder.Entity<InstitutionServices>(entity =>
            {
                entity.HasKey(e => e.InstitutionServiceId);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.HasOne(d => d.InstitutionBranch)
                    .WithMany(p => p.InstitutionServices)
                    .HasForeignKey(d => d.InstitutionBranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InstitutionServices_InstitutionBranch");

                entity.HasOne(d => d.InstitutionDoctor)
                    .WithMany(p => p.InstitutionServices)
                    .HasForeignKey(d => d.InstitutionDoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InstitutionServices_InstitutionDoctor");

                entity.HasOne(d => d.PlatformService)
                    .WithMany(p => p.InstitutionServices)
                    .HasForeignKey(d => d.PlatformServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InstitutionServices_PlatformService");
            });

            modelBuilder.Entity<InstitutionSpecialties>(entity =>
            {
                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.HasOne(d => d.InstitutionBranch)
                    .WithMany(p => p.InstitutionSpecialties)
                    .HasForeignKey(d => d.InstitutionBranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InstitutionSpecialties_Institution");

                entity.HasOne(d => d.Specialty)
                    .WithMany(p => p.InstitutionSpecialties)
                    .HasForeignKey(d => d.SpecialtyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InstitutionSpecialties_Specialty");
            });

            modelBuilder.Entity<InstitutionSubSpecialties>(entity =>
            {
                entity.HasKey(e => e.InstintutionSubSpecialtyId)
                    .HasName("PK_InstitutionSubSpecialty");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.HasOne(d => d.InstitutionBranch)
                    .WithMany(p => p.InstitutionSubSpecialties)
                    .HasForeignKey(d => d.InstitutionBranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InstitutionSubSpecialty_InstitutionBranch");

                entity.HasOne(d => d.PlatformSubSpecialty)
                    .WithMany(p => p.InstitutionSubSpecialties)
                    .HasForeignKey(d => d.PlatformSubSpecialtyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InstitutionSubSpecialty_SubSpecialty");
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.MemberEmail)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.MemberPassword)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.MemberStatus)
                    .WithMany(p => p.MemberMemberStatus)
                    .HasForeignKey(d => d.MemberStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Member_Status");

                entity.HasOne(d => d.MemberType)
                    .WithMany(p => p.MemberMemberType)
                    .HasForeignKey(d => d.MemberTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Member_Type");
            });

            modelBuilder.Entity<MemberDetails>(entity =>
            {
                entity.HasKey(e => e.MemberId)
                    .HasName("PK_MemberDetails_1");

                entity.Property(e => e.MemberId).ValueGeneratedNever();

                entity.Property(e => e.About).HasMaxLength(200);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Embg).HasColumnName("EMBG");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ProfilePicture).HasMaxLength(80);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.MemberDetails)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_MemberDetails_Address");

                entity.HasOne(d => d.Member)
                    .WithOne(p => p.MemberDetails)
                    .HasForeignKey<MemberDetails>(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberDetails_Member");
            });

            modelBuilder.Entity<MemberInvitation>(entity =>
            {
                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.InvitationCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.MemberInvitation)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberInvitation_Member");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.MemberInvitation)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MemberInvitation_Status");
            });

            modelBuilder.Entity<PatientHistory>(entity =>
            {
                entity.Property(e => e.Diagnose)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.DoctorInternNote)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.FindingNote)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.TreatmentNote)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.PatientHistory)
                    .HasForeignKey(d => d.AppointmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientHistory_Appointment");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.TotalAmount)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.CreditCard)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.CreditCardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payment_CreditCard");

                entity.HasOne(d => d.PaymentStatus)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.PaymentStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payment_Status");
            });

            modelBuilder.Entity<PlatformConfiguration>(entity =>
            {
                entity.HasKey(e => e.Value);

                entity.Property(e => e.Value).ValueGeneratedNever();

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Icon).HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.ProgramCode)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<PlatformService>(entity =>
            {
                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.Specialty)
                    .WithMany(p => p.PlatformService)
                    .HasForeignKey(d => d.SpecialtyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PlatformService_Specialty");

                entity.HasOne(d => d.SubSpecialty)
                    .WithMany(p => p.PlatformService)
                    .HasForeignKey(d => d.SubSpecialtyId)
                    .HasConstraintName("FK_PlatformService_SubSpecialty");
            });

            modelBuilder.Entity<PlatformSpecialty>(entity =>
            {
                entity.HasKey(e => e.SpecialtyId)
                    .HasName("PK_Specialty");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PlatformSubSpecialty>(entity =>
            {
                entity.HasKey(e => e.SubSpecialtyId)
                    .HasName("PK_SubSpecialty");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Specialty)
                    .WithMany(p => p.PlatformSubSpecialty)
                    .HasForeignKey(d => d.SpecialtyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubSpecialty_Specialty");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Service)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Service_Doctor");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
