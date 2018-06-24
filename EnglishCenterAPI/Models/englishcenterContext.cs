using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EnglishCenterAPI.Models
{
    public partial class englishcenterContext : DbContext
    {
        public virtual DbSet<Classes> Classes { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Exercise> Exercise { get; set; }
        public virtual DbSet<Rating> Rating { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserClass> UserClass { get; set; }
        public virtual DbSet<UserComment> UserComment { get; set; }
        public virtual DbSet<UserOrder> UserOrder { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //                optionsBuilder.UseSqlServer(@"Server=DESKTOP-8G43GIA;Database=englishcenter;User ID=sa;Password=123456;Trusted_Connection=True;");
        //            }
        //        }

        public englishcenterContext(DbContextOptions<englishcenterContext> context) : base(context) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Classes>(entity =>
            {
                entity.HasKey(e => e.IdClass);

                entity.Property(e => e.IdClass).HasColumnName("id_class");

                entity.Property(e => e.EndDate)
                    .HasColumnName("end_date")
                    .HasColumnType("char(10)");

                entity.Property(e => e.IdCourse).HasColumnName("id_course");

                entity.Property(e => e.Location)
                    .HasColumnName("location")
                    .HasColumnType("char(50)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("char(50)");

                entity.Property(e => e.Size)
                    .HasColumnName("size")
                    .HasColumnType("char(10)");

                entity.Property(e => e.StartDate)
                    .HasColumnName("start_date")
                    .HasColumnType("char(10)");

                entity.HasOne(d => d.IdCourseNavigation)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.IdCourse)
                    .HasConstraintName("FK_Class_0");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(e => e.IdComment);

                entity.Property(e => e.IdComment).HasColumnName("id_comment");

                entity.Property(e => e.Content)
                    .HasMaxLength(3000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(e => e.IdCourse);

                entity.Property(e => e.IdCourse).HasColumnName("id_course");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("char(10)");

                entity.Property(e => e.NumberOfStudent).HasColumnName("number_of_student");
            });

            modelBuilder.Entity<Exercise>(entity =>
            {
                entity.HasKey(e => e.IdExercise);

                entity.Property(e => e.IdExercise).HasColumnName("id_exercise");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasMaxLength(3000)
                    .IsUnicode(false);

                entity.Property(e => e.IdCourse).HasColumnName("id_course");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasColumnType("char(100)");

                entity.HasOne(d => d.IdCourseNavigation)
                    .WithMany(p => p.Exercise)
                    .HasForeignKey(d => d.IdCourse)
                    .HasConstraintName("FK_Exercise_0");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.HasKey(e => e.IdRating);

                entity.Property(e => e.IdRating).HasColumnName("id_rating");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.IdCourse).HasColumnName("id_course");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.Point)
                    .HasColumnName("point")
                    .HasColumnType("char(10)");

                entity.HasOne(d => d.IdCourseNavigation)
                    .WithMany(p => p.Rating)
                    .HasForeignKey(d => d.IdCourse)
                    .HasConstraintName("FK_Rating_1");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Rating)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_Rating_0");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRole);

                entity.Property(e => e.IdRole).HasColumnName("id_role");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("char(10)");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Birthday)
                    .HasColumnName("birthday")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasColumnType("char(10)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("char(100)");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasColumnType("nchar(20)");

                entity.Property(e => e.Pol)
                    .HasColumnName("pol")
                    .HasColumnType("char(10)");
            });

            modelBuilder.Entity<UserClass>(entity =>
            {
                entity.HasKey(e => e.IdUserClass);

                entity.Property(e => e.IdUserClass).HasColumnName("id_user_class");

                entity.Property(e => e.IdClass).HasColumnName("id_class");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.HasOne(d => d.IdClassNavigation)
                    .WithMany(p => p.UserClass)
                    .HasForeignKey(d => d.IdClass)
                    .HasConstraintName("FK_UserClass_1");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.UserClass)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_UserClass_0");
            });

            modelBuilder.Entity<UserComment>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdComment).HasColumnName("id_comment");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.HasOne(d => d.IdCommentNavigation)
                    .WithMany(p => p.UserComment)
                    .HasForeignKey(d => d.IdComment)
                    .HasConstraintName("FK_UserComment_1");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.UserComment)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_UserComment_0");
            });

            modelBuilder.Entity<UserOrder>(entity =>
            {
                entity.HasKey(e => e.IdOrder);

                entity.Property(e => e.IdOrder).HasColumnName("id_order");

                entity.Property(e => e.DateCreate)
                    .HasColumnName("date_create")
                    .HasColumnType("char(10)");

                entity.Property(e => e.DateUpdate)
                    .HasColumnName("date_update")
                    .HasColumnType("char(10)");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("char(10)");

                entity.Property(e => e.PromotionCode)
                    .HasColumnName("promotion_code")
                    .HasColumnType("char(10)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("char(10)");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("char(10)");

                entity.Property(e => e.UserOrder1)
                    .HasColumnName("user_order")
                    .HasColumnType("char(100)");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.UserOrder)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_TOrder_0");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdRole).HasColumnName("id_role");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.IdRole)
                    .HasConstraintName("FK_UserRole_0");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_UserRole_1");
            });
        }
    }
}
