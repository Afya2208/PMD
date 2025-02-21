using System;
using System.Collections.Generic;

namespace PersonnelManagementDeskrop.Entities;

public partial class Worker
{
    public int Id { get; set; }

    public string? LastName { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public DateTime? DateBirthday { get; set; }

    public int? PositionId { get; set; }

    public int? DivisionId { get; set; }

    public string? WorkPhone { get; set; }

    public string? PersonalPhone { get; set; }

    public string? WorkEmail { get; set; }

    public string? Office { get; set; }

    public int? BossId { get; set; }

    public int? HelperId { get; set; }

    public DateTime? DateFired { get; set; }

    public string? OtherInfo { get; set; }

    public virtual Worker? Boss { get; set; }

    public virtual Division? Division { get; set; }

    public virtual ICollection<Division> Divisions { get; set; } = new List<Division>();

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual Worker? Helper { get; set; }

    public virtual ICollection<Worker> InverseBoss { get; set; } = new List<Worker>();

    public virtual ICollection<Worker> InverseHelper { get; set; } = new List<Worker>();

    public virtual Position? Position { get; set; }

    public virtual ICollection<WorkerAbsence> WorkerAbsenceWorkerInsteads { get; set; } = new List<WorkerAbsence>();

    public virtual ICollection<WorkerAbsence> WorkerAbsenceWorkers { get; set; } = new List<WorkerAbsence>();
}
