// using System;
// using System.Collections.Generic;
// using Microsoft.EntityFrameworkCore;

// namespace GSRS.Demo.BusinessService.OModel;

// public partial class GsrsContext : DbContext
// {
//     public GsrsContext()
//     {
//     }

//     public GsrsContext(DbContextOptions<GsrsContext> options)
//         : base(options)
//     {
//     }

//     public virtual DbSet<Agreement> Agreements { get; set; }

//     public virtual DbSet<AutoImportType> AutoImportTypes { get; set; }

//     public virtual DbSet<CostModel> CostModels { get; set; }

//     public virtual DbSet<ImportType> ImportTypes { get; set; }

//     public virtual DbSet<LicenseServer> LicenseServers { get; set; }

//     public virtual DbSet<LicenseServerGroup> LicenseServerGroups { get; set; }

//     public virtual DbSet<LicenseType> LicenseTypes { get; set; }

//     public virtual DbSet<Product> Products { get; set; }

//     public virtual DbSet<ProductGroup> ProductGroups { get; set; }

//     public virtual DbSet<ProductGroupPrice> ProductGroupPrices { get; set; }

//     public virtual DbSet<UnitDefinition> UnitDefinitions { get; set; }

//     public virtual DbSet<UnitFactor> UnitFactors { get; set; }

//     public virtual DbSet<Vendor> Vendors { get; set; }

//     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//         => optionsBuilder.UseSqlServer("Server=ASPLAP3099; Database=GSRS;Trusted_Connection=True;Trustservercertificate=True;");

//     protected override void OnModelCreating(ModelBuilder modelBuilder)
//     {
//         modelBuilder.Entity<Agreement>(entity =>
//         {
//             entity.HasKey(e => e.Id).HasName("PK__Agreemen__3214EC07CE598AD9");

//             entity.ToTable("Agreement");

//             entity.Property(e => e.AgreementCode)
//                 .HasMaxLength(50)
//                 .IsUnicode(false);
//             entity.Property(e => e.ChangedBy)
//                 .HasMaxLength(50)
//                 .IsUnicode(false);
//             entity.Property(e => e.Comment).HasMaxLength(510);
//             entity.Property(e => e.DateChanged).HasColumnType("datetime");
//             entity.Property(e => e.DateCreated).HasColumnType("datetime");
//             entity.Property(e => e.Description).HasMaxLength(510);
//             entity.Property(e => e.FinanceResponsible).HasMaxLength(510);
//             entity.Property(e => e.InitialsResponsible)
//                 .HasMaxLength(50)
//                 .IsUnicode(false);
//             entity.Property(e => e.LocalCountryIso).HasMaxLength(510);
//             entity.Property(e => e.MacIncomeDepartment)
//                 .HasMaxLength(20)
//                 .IsUnicode(false);
//             entity.Property(e => e.MacPostingAccount)
//                 .HasMaxLength(20)
//                 .IsUnicode(false);
//             entity.Property(e => e.MacProjectNo)
//                 .HasMaxLength(20)
//                 .IsUnicode(false);
//             entity.Property(e => e.MacTaskNameLic)
//                 .HasMaxLength(50)
//                 .IsUnicode(false)
//                 .HasColumnName("MacTaskName_LIC");
//             entity.Property(e => e.MackTaskNameNondk)
//                 .HasMaxLength(50)
//                 .IsUnicode(false)
//                 .HasColumnName("MackTaskName_nondk");

//             entity.HasOne(d => d.Vendor).WithMany(p => p.Agreements)
//                 .HasForeignKey(d => d.VendorId)
//                 .OnDelete(DeleteBehavior.ClientSetNull)
//                 .HasConstraintName("FK__Agreement__Vendo__267ABA7A");
//         });

//         modelBuilder.Entity<AutoImportType>(entity =>
//         {
//             entity.HasKey(e => e.Id).HasName("PK__AutoImpo__3214EC07DC3E4DE4");

//             entity.ToTable("AutoImportType");

//             entity.Property(e => e.AutoImportCode)
//                 .HasMaxLength(20)
//                 .IsUnicode(false);
//             entity.Property(e => e.ChangedBy)
//                 .HasMaxLength(50)
//                 .IsUnicode(false);
//             entity.Property(e => e.DateChanged).HasColumnType("datetime");
//             entity.Property(e => e.DateCreated).HasColumnType("datetime");
//             entity.Property(e => e.Description).HasMaxLength(510);
//         });

//         modelBuilder.Entity<CostModel>(entity =>
//         {
//             entity.HasKey(e => e.Id).HasName("PK__CostMode__3214EC076198DF31");

//             entity.ToTable("CostModel");

//             entity.Property(e => e.ChangedBy)
//                 .HasMaxLength(50)
//                 .IsUnicode(false);
//             entity.Property(e => e.CostModelName)
//                 .HasMaxLength(20)
//                 .IsUnicode(false);
//             entity.Property(e => e.DateChanged).HasColumnType("datetime");
//             entity.Property(e => e.DateCreated).HasColumnType("datetime");
//             entity.Property(e => e.Description)
//                 .HasMaxLength(200)
//                 .IsUnicode(false);
//         });

//         modelBuilder.Entity<ImportType>(entity =>
//         {
//             entity.HasKey(e => e.Id).HasName("PK__ImportTy__3214EC07CF874F69");

//             entity.ToTable("ImportType");

//             entity.Property(e => e.ChangedBy)
//                 .HasMaxLength(50)
//                 .IsUnicode(false);
//             entity.Property(e => e.DateChanged).HasColumnType("datetime");
//             entity.Property(e => e.DateCreated).HasColumnType("datetime");
//             entity.Property(e => e.Description)
//                 .HasMaxLength(225)
//                 .IsUnicode(false);
//             entity.Property(e => e.ImportTypeName)
//                 .HasMaxLength(50)
//                 .IsUnicode(false);
//         });

//         modelBuilder.Entity<LicenseServer>(entity =>
//         {
//             entity.HasKey(e => e.Id).HasName("PK__LicenseS__3214EC07AEB00DCD");

//             entity.ToTable("LicenseServer");

//             entity.Property(e => e.ChangedBy)
//                 .HasMaxLength(50)
//                 .IsUnicode(false);
//             entity.Property(e => e.Comment).HasMaxLength(1);
//             entity.Property(e => e.Country)
//                 .HasMaxLength(50)
//                 .IsUnicode(false);
//             entity.Property(e => e.DateChaged).HasColumnType("datetime");
//             entity.Property(e => e.DateCreated).HasColumnType("datetime");
//             entity.Property(e => e.Descriptions)
//                 .HasMaxLength(100)
//                 .IsUnicode(false);
//             entity.Property(e => e.FolderName)
//                 .HasMaxLength(50)
//                 .IsUnicode(false);
//             entity.Property(e => e.ServerName).HasMaxLength(1);
//             entity.Property(e => e.UdlFileName)
//                 .HasMaxLength(50)
//                 .IsUnicode(false);

//             entity.HasOne(d => d.AutoImportType).WithMany(p => p.LicenseServers)
//                 .HasForeignKey(d => d.AutoImportTypeId)
//                 .HasConstraintName("FK__LicenseSe__AutoI__3A81B327");

//             entity.HasOne(d => d.LicServerGroup).WithMany(p => p.LicenseServers)
//                 .HasForeignKey(d => d.LicServerGroupId)
//                 .HasConstraintName("FK__LicenseSe__LicSe__38996AB5");

//             entity.HasOne(d => d.LicType).WithMany(p => p.LicenseServers)
//                 .HasForeignKey(d => d.LicTypeId)
//                 .HasConstraintName("FK__LicenseSe__LicTy__398D8EEE");
//         });

//         modelBuilder.Entity<LicenseServerGroup>(entity =>
//         {
//             entity.HasKey(e => e.Id).HasName("PK__LicenseS__3214EC07BA7EFC92");

//             entity.ToTable("LicenseServerGroup");

//             entity.Property(e => e.ChangedBy)
//                 .HasMaxLength(50)
//                 .IsUnicode(false);
//             entity.Property(e => e.CountryIso)
//                 .HasMaxLength(50)
//                 .IsUnicode(false);
//             entity.Property(e => e.DateChanged).HasColumnType("datetime");
//             entity.Property(e => e.DateCreated).HasColumnType("datetime");
//             entity.Property(e => e.ServerGroupName)
//                 .HasMaxLength(50)
//                 .IsUnicode(false);
//         });

//         modelBuilder.Entity<LicenseType>(entity =>
//         {
//             entity.HasKey(e => e.Id).HasName("PK__LicenseT__3214EC07F9F1424F");

//             entity.ToTable("LicenseType");

//             entity.Property(e => e.ChangedBy)
//                 .HasMaxLength(50)
//                 .IsUnicode(false);
//             entity.Property(e => e.DateChanged).HasColumnType("datetime");
//             entity.Property(e => e.DateCreated).HasColumnType("datetime");
//             entity.Property(e => e.ImportFrequency)
//                 .HasMaxLength(1)
//                 .IsUnicode(false)
//                 .IsFixedLength();
//             entity.Property(e => e.LicTypeName)
//                 .HasMaxLength(50)
//                 .IsUnicode(false);

//             entity.HasOne(d => d.ImportType).WithMany(p => p.LicenseTypes)
//                 .HasForeignKey(d => d.ImportTypeId)
//                 .HasConstraintName("FK__LicenseTy__Impor__35BCFE0A");
//         });

//         modelBuilder.Entity<Product>(entity =>
//         {
//             entity.HasKey(e => e.Id).HasName("PK__Product__3214EC072B4B386D");

//             entity.ToTable("Product");

//             entity.Property(e => e.ChangedBy)
//                 .HasMaxLength(50)
//                 .IsUnicode(false);
//             entity.Property(e => e.Comment)
//                 .HasMaxLength(1000)
//                 .IsUnicode(false);
//             entity.Property(e => e.DateChanged).HasColumnType("datetime");
//             entity.Property(e => e.DateCreated).HasColumnType("datetime");
//             entity.Property(e => e.DisplayName)
//                 .HasMaxLength(80)
//                 .IsUnicode(false);
//             entity.Property(e => e.FeaturesKey)
//                 .HasMaxLength(80)
//                 .IsUnicode(false);
//             entity.Property(e => e.ManufacturerName).HasMaxLength(160);

//             entity.HasOne(d => d.LicType).WithMany(p => p.Products)
//                 .HasForeignKey(d => d.LicTypeId)
//                 .HasConstraintName("FK__Product__LicType__4316F928");

//             entity.HasOne(d => d.ProductGroup).WithMany(p => p.Products)
//                 .HasForeignKey(d => d.ProductGroupId)
//                 .HasConstraintName("FK__Product__Product__4222D4EF");
//         });

//         modelBuilder.Entity<ProductGroup>(entity =>
//         {
//             entity.HasKey(e => e.Id).HasName("PK__ProductG__3214EC074246250A");

//             entity.ToTable("ProductGroup");

//             entity.Property(e => e.ChangedBy)
//                 .HasMaxLength(50)
//                 .IsUnicode(false);
//             entity.Property(e => e.Comment).HasMaxLength(510);
//             entity.Property(e => e.DateChanged).HasColumnType("datetime");
//             entity.Property(e => e.DateCreated).HasColumnType("datetime");
//             entity.Property(e => e.ProductGroupCode)
//                 .HasMaxLength(50)
//                 .IsUnicode(false);
//             entity.Property(e => e.ProductGroupName)
//                 .HasMaxLength(510)
//                 .IsUnicode(false);
//             entity.Property(e => e.SupportgroupId).HasColumnName("SupportgroupID");

//             entity.HasOne(d => d.Agreement).WithMany(p => p.ProductGroups)
//                 .HasForeignKey(d => d.AgreementId)
//                 .OnDelete(DeleteBehavior.ClientSetNull)
//                 .HasConstraintName("FK__ProductGr__Agree__3D5E1FD2");

//             entity.HasOne(d => d.CostModel).WithMany(p => p.ProductGroups)
//                 .HasForeignKey(d => d.CostModelId)
//                 .HasConstraintName("FK__ProductGr__CostM__3F466844");

//             entity.HasOne(d => d.UnitFactor).WithMany(p => p.ProductGroups)
//                 .HasForeignKey(d => d.UnitFactorId)
//                 .OnDelete(DeleteBehavior.ClientSetNull)
//                 .HasConstraintName("FK__ProductGr__UnitF__3E52440B");
//         });

//         modelBuilder.Entity<ProductGroupPrice>(entity =>
//         {
//             entity.HasKey(e => e.Id).HasName("PK__ProductG__3214EC079DA48A82");

//             entity.ToTable("ProductGroupPrice");

//             entity.Property(e => e.ChangedBy)
//                 .HasMaxLength(50)
//                 .IsUnicode(false);
//             entity.Property(e => e.DateChanged).HasColumnType("datetime");
//             entity.Property(e => e.DateCreated).HasColumnType("datetime");
//             entity.Property(e => e.DateEnd).HasColumnType("date");
//             entity.Property(e => e.DateStart).HasColumnType("date");
//             entity.Property(e => e.Description)
//                 .HasMaxLength(255)
//                 .IsUnicode(false);
//             entity.Property(e => e.MacComment)
//                 .HasMaxLength(255)
//                 .IsUnicode(false);

//             entity.HasOne(d => d.LicServerGroup).WithMany(p => p.ProductGroupPrices)
//                 .HasForeignKey(d => d.LicServerGroupId)
//                 .OnDelete(DeleteBehavior.ClientSetNull)
//                 .HasConstraintName("FK__ProductGr__LicSe__46E78A0C");

//             entity.HasOne(d => d.ProductGroup).WithMany(p => p.ProductGroupPrices)
//                 .HasForeignKey(d => d.ProductGroupId)
//                 .OnDelete(DeleteBehavior.ClientSetNull)
//                 .HasConstraintName("FK__ProductGr__Produ__45F365D3");
//         });

//         modelBuilder.Entity<UnitDefinition>(entity =>
//         {
//             entity.HasKey(e => e.Id).HasName("PK__UnitDefi__3214EC07DED17DB2");

//             entity.ToTable("UnitDefinition");

//             entity.Property(e => e.ChangedBy)
//                 .HasMaxLength(50)
//                 .IsUnicode(false);
//             entity.Property(e => e.DateChanged).HasColumnType("datetime");
//             entity.Property(e => e.DateCreated).HasColumnType("datetime");
//             entity.Property(e => e.Description).HasMaxLength(510);
//             entity.Property(e => e.ShortDescription)
//                 .HasMaxLength(50)
//                 .IsUnicode(false);
//             entity.Property(e => e.UnitDefinitionCode)
//                 .HasMaxLength(20)
//                 .IsUnicode(false);
//             entity.Property(e => e.UsageTip).HasMaxLength(510);
//         });

//         modelBuilder.Entity<UnitFactor>(entity =>
//         {
//             entity.HasKey(e => e.Id).HasName("PK__UnitFact__3214EC07699ADC5A");

//             entity.ToTable("UnitFactor");

//             entity.Property(e => e.ChangedBy)
//                 .HasMaxLength(50)
//                 .IsUnicode(false);
//             entity.Property(e => e.DateChanged).HasColumnType("datetime");
//             entity.Property(e => e.DateCreated).HasColumnType("datetime");
//             entity.Property(e => e.Description).HasMaxLength(510);
//             entity.Property(e => e.UnitFactorCode)
//                 .HasMaxLength(50)
//                 .IsUnicode(false);

//             entity.HasOne(d => d.UnitDefinition).WithMany(p => p.UnitFactors)
//                 .HasForeignKey(d => d.UnitDefinitionId)
//                 .OnDelete(DeleteBehavior.ClientSetNull)
//                 .HasConstraintName("FK__UnitFacto__UnitD__30F848ED");
//         });

//         modelBuilder.Entity<Vendor>(entity =>
//         {
//             entity.HasKey(e => e.Id).HasName("PK__Vendor__3214EC07F7CF738E");

//             entity.ToTable("Vendor");

//             entity.Property(e => e.ChangedBy)
//                 .HasMaxLength(50)
//                 .IsUnicode(false);
//             entity.Property(e => e.DateChanged).HasColumnType("datetime");
//             entity.Property(e => e.DateCreated).HasColumnType("datetime");
//             entity.Property(e => e.VendorAddress).HasMaxLength(510);
//             entity.Property(e => e.VendorCode)
//                 .HasMaxLength(50)
//                 .IsUnicode(false);
//             entity.Property(e => e.VendorName).HasMaxLength(510);
//         });

//         OnModelCreatingPartial(modelBuilder);
//     }

//     partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
// }
