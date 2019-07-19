namespace CONVINEC.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbModel : DbContext
    {
        public DbModel()
            : base("name=DbModel")
        {
        }

        public virtual DbSet<ActionLog> ActionLog { get; set; }
        public virtual DbSet<IndicatorHistory> IndicatorHistory { get; set; }
        public virtual DbSet<Occupation> Occupation { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<QuestionActivity> QuestionActivity { get; set; }
        public virtual DbSet<SystemLog> SystemLog { get; set; }
        public virtual DbSet<Topic> Topic { get; set; }
        public virtual DbSet<TypeAction> TypeAction { get; set; }
        public virtual DbSet<TypeActionLog> TypeActionLog { get; set; }
        public virtual DbSet<TypeIndicator> TypeIndicator { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActionLog>()
                .Property(e => e.notes)
                .IsUnicode(false);

            modelBuilder.Entity<IndicatorHistory>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<Occupation>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<Occupation>()
                .HasMany(e => e.User)
                .WithRequired(e => e.Occupation)
                .HasForeignKey(e => e.fkOccupation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Question>()
                .Property(e => e.fullName)
                .IsUnicode(false);

            modelBuilder.Entity<Question>()
                .Property(e => e.tittle)
                .IsUnicode(false);

            modelBuilder.Entity<Question>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<Question>()
                .HasMany(e => e.QuestionActivity)
                .WithRequired(e => e.Question)
                .HasForeignKey(e => e.fkQuestion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QuestionActivity>()
                .Property(e => e.fullname)
                .IsUnicode(false);

            modelBuilder.Entity<QuestionActivity>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<SystemLog>()
                .Property(e => e.table)
                .IsUnicode(false);

            modelBuilder.Entity<SystemLog>()
                .Property(e => e.column)
                .IsUnicode(false);

            modelBuilder.Entity<SystemLog>()
                .Property(e => e.previousValue)
                .IsUnicode(false);

            modelBuilder.Entity<SystemLog>()
                .Property(e => e.notes)
                .IsUnicode(false);

            modelBuilder.Entity<Topic>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<Topic>()
                .HasMany(e => e.Question)
                .WithRequired(e => e.Topic)
                .HasForeignKey(e => e.fkTopic)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TypeAction>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<TypeAction>()
                .HasMany(e => e.QuestionActivity)
                .WithRequired(e => e.TypeAction)
                .HasForeignKey(e => e.fkTypeAction)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TypeActionLog>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<TypeActionLog>()
                .HasMany(e => e.ActionLog)
                .WithRequired(e => e.TypeActionLog)
                .HasForeignKey(e => e.fkTypeActionLog)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TypeIndicator>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<TypeIndicator>()
                .HasMany(e => e.IndicatorHistory)
                .WithRequired(e => e.TypeIndicator)
                .HasForeignKey(e => e.fkTypeIndicator)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.DNI)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.fullName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.address)
                .IsUnicode(false);
        }
    }
}
