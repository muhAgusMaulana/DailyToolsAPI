using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace DailyToolsAPI.Models
{
    public partial class DailyToolsContext : DbContext
    {
        public DailyToolsContext()
        {
        }

        public DailyToolsContext(DbContextOptions<DailyToolsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountType> AccountTypes { get; set; }
        public virtual DbSet<Apilog> Apilogs { get; set; }
        public virtual DbSet<Response> Responses { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<TaskLog> TaskLogs { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserAccount> UserAccounts { get; set; }
        public virtual DbSet<UserAccountLog> UserAccountLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                optionsBuilder.UseSqlServer(config.GetConnectionString("Local"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AccountType>(entity =>
            {
                entity.HasKey(e => e.AccountTypeCode);

                entity.ToTable("AccountType");

                entity.Property(e => e.AccountTypeCode)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.AccountTypeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InputTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.InputUn)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("InputUN")
                    .HasDefaultValueSql("(suser_name())");

                entity.Property(e => e.ModifTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifUn)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ModifUN")
                    .HasDefaultValueSql("(suser_name())");
            });

            modelBuilder.Entity<Apilog>(entity =>
            {
                entity.ToTable("APILog");

                entity.Property(e => e.ApilogId)
                    .HasColumnName("APILogID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Apiname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("APIName");

                entity.Property(e => e.Apiparam)
                    .IsUnicode(false)
                    .HasColumnName("APIParam");

                entity.Property(e => e.Apiresponse)
                    .HasColumnType("text")
                    .HasColumnName("APIResponse");

                entity.Property(e => e.Exception).HasColumnType("text");

                entity.Property(e => e.InputTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.InputUn)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("InputUN");
            });

            modelBuilder.Entity<Response>(entity =>
            {
                entity.HasKey(e => new { e.ModuleName, e.ResponseType, e.ResponseCode });

                entity.ToTable("Response");

                entity.Property(e => e.ModuleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ResponseType)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.ResponseCode)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.ResponseMessage)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("Task");

                entity.Property(e => e.TaskId)
                    .HasColumnName("TaskID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.InputTime).HasColumnType("datetime");

                entity.Property(e => e.InputUn)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("InputUN");

                entity.Property(e => e.ModifTime).HasColumnType("datetime");

                entity.Property(e => e.ModifUn)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ModifUN");

                entity.Property(e => e.TaskDateFrom).HasColumnType("datetime");

                entity.Property(e => e.TaskDateTo).HasColumnType("datetime");

                entity.Property(e => e.TaskName)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TaskLog>(entity =>
            {
                entity.ToTable("TaskLog");

                entity.Property(e => e.TaskLogId)
                    .HasColumnName("TaskLogID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.InputTime).HasColumnType("datetime");

                entity.Property(e => e.InputUn)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("InputUN");

                entity.Property(e => e.TaskId).HasColumnName("TaskID");

                entity.Property(e => e.TaskLogMessage).IsUnicode(false);

                entity.Property(e => e.TaskTransTypeCode)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserName)
                    .HasName("PK_MS_User");

                entity.ToTable("User");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.InputTime).HasColumnType("datetime");

                entity.Property(e => e.InputUn)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("InputUN");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ModifTime).HasColumnType("datetime");

                entity.Property(e => e.ModifUn)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ModifUN");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PhotoUrl)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("PhotoURL");
            });

            modelBuilder.Entity<UserAccount>(entity =>
            {
                entity.HasKey(e => new { e.UserName, e.AccountTypeCode })
                    .HasName("PK_UserAccount_1");

                entity.ToTable("UserAccount");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AccountTypeCode)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.AmountBalance).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.InputTime).HasColumnType("datetime");

                entity.Property(e => e.InputUn)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("InputUN");

                entity.Property(e => e.ModifTime).HasColumnType("datetime");

                entity.Property(e => e.ModifUn)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ModifUN");

                entity.Property(e => e.UserAccountId)
                    .HasColumnName("UserAccountID")
                    .HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<UserAccountLog>(entity =>
            {
                entity.ToTable("UserAccountLog");

                entity.Property(e => e.UserAccountLogId)
                    .HasColumnName("UserAccountLogID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.InputTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.InputUn)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("InputUN");

                entity.Property(e => e.ModifTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifUn)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ModifUN");

                entity.Property(e => e.OperationType)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.TargetUserAccountId).HasColumnName("TargetUserAccountID");

                entity.Property(e => e.UserAccountId).HasColumnName("UserAccountID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
