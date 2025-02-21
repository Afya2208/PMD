using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PersonnelManagementDeskrop.Entities;

public partial class PersonnelManagementDbHomeContext : DbContext
{
    public PersonnelManagementDbHomeContext()
    {
    }

    public PersonnelManagementDbHomeContext(DbContextOptions<PersonnelManagementDbHomeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AbsenceType> AbsenceTypes { get; set; }

    public virtual DbSet<Division> Divisions { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventType> EventTypes { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Worker> Workers { get; set; }

    public virtual DbSet<WorkerAbsence> WorkerAbsences { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("host=localhost;port=5432;database=personnel_management_db_home;username=postgres;password=1111");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AbsenceType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("absence_type_pkey");

            entity.ToTable("absence_type");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Division>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("division_pkey");

            entity.ToTable("division");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(3000)
                .HasColumnName("description");
            entity.Property(e => e.HeadDivisionId).HasColumnName("head_division_id");
            entity.Property(e => e.HeadWorkerId).HasColumnName("head_worker_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");

            entity.HasOne(d => d.HeadDivision).WithMany(p => p.InverseHeadDivision)
                .HasForeignKey(d => d.HeadDivisionId)
                .HasConstraintName("division_head_division_id_fkey");

            entity.HasOne(d => d.HeadWorker).WithMany(p => p.Divisions)
                .HasForeignKey(d => d.HeadWorkerId)
                .HasConstraintName("division_head_worker_id_fkey");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("event_pkey");

            entity.ToTable("event");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.DateCreated)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date_created");
            entity.Property(e => e.DateEnd)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date_end");
            entity.Property(e => e.DateStart)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date_start");
            entity.Property(e => e.Description)
                .HasMaxLength(3000)
                .HasColumnName("description");
            entity.Property(e => e.EventTypeId).HasColumnName("event_type_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Place)
                .HasMaxLength(100)
                .HasColumnName("place");
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .HasColumnName("status");

            entity.HasOne(d => d.Author).WithMany(p => p.Events)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("event_author_id_fkey");

            entity.HasOne(d => d.EventType).WithMany(p => p.Events)
                .HasForeignKey(d => d.EventTypeId)
                .HasConstraintName("event_event_type_id_fkey");
        });

        modelBuilder.Entity<EventType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("event_type_pkey");

            entity.ToTable("event_type");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("position_pkey");

            entity.ToTable("position");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Worker>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("worker_pkey");

            entity.ToTable("worker");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BossId).HasColumnName("boss_id");
            entity.Property(e => e.DateBirthday)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date_birthday");
            entity.Property(e => e.DateFired)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date_fired");
            entity.Property(e => e.DivisionId).HasColumnName("division_id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("first_name");
            entity.Property(e => e.HelperId).HasColumnName("helper_id");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("last_name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(100)
                .HasColumnName("middle_name");
            entity.Property(e => e.Office)
                .HasMaxLength(10)
                .HasColumnName("office");
            entity.Property(e => e.OtherInfo)
                .HasMaxLength(3000)
                .HasColumnName("other_info");
            entity.Property(e => e.PersonalPhone)
                .HasMaxLength(20)
                .HasColumnName("personal_phone");
            entity.Property(e => e.PositionId).HasColumnName("position_id");
            entity.Property(e => e.WorkEmail)
                .HasMaxLength(100)
                .HasColumnName("work_email");
            entity.Property(e => e.WorkPhone)
                .HasMaxLength(20)
                .HasColumnName("work_phone");

            entity.HasOne(d => d.Boss).WithMany(p => p.InverseBoss)
                .HasForeignKey(d => d.BossId)
                .HasConstraintName("worker_boss_id_fkey");

            entity.HasOne(d => d.Division).WithMany(p => p.Workers)
                .HasForeignKey(d => d.DivisionId)
                .HasConstraintName("worker_division_id_fkey");

            entity.HasOne(d => d.Helper).WithMany(p => p.InverseHelper)
                .HasForeignKey(d => d.HelperId)
                .HasConstraintName("worker_helper_id_fkey");

            entity.HasOne(d => d.Position).WithMany(p => p.Workers)
                .HasForeignKey(d => d.PositionId)
                .HasConstraintName("worker_position_id_fkey");
        });

        modelBuilder.Entity<WorkerAbsence>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("worker_absence_pkey");

            entity.ToTable("worker_absence");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AbsenceTypeId).HasColumnName("absence_type_id");
            entity.Property(e => e.DateEnd)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date_end");
            entity.Property(e => e.DateStart)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date_start");
            entity.Property(e => e.Reason)
                .HasMaxLength(100)
                .HasColumnName("reason");
            entity.Property(e => e.WorkerId).HasColumnName("worker_id");
            entity.Property(e => e.WorkerInsteadId).HasColumnName("worker_instead_id");

            entity.HasOne(d => d.AbsenceType).WithMany(p => p.WorkerAbsences)
                .HasForeignKey(d => d.AbsenceTypeId)
                .HasConstraintName("worker_absence_absence_type_id_fkey");

            entity.HasOne(d => d.Worker).WithMany(p => p.WorkerAbsenceWorkers)
                .HasForeignKey(d => d.WorkerId)
                .HasConstraintName("worker_absence_worker_id_fkey");

            entity.HasOne(d => d.WorkerInstead).WithMany(p => p.WorkerAbsenceWorkerInsteads)
                .HasForeignKey(d => d.WorkerInsteadId)
                .HasConstraintName("worker_absence_worker_instead_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
