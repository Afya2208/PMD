using System;
using System.Collections.Generic;

namespace PersonnelManagementDeskrop.Entities;

public partial class WorkerAbsence
{
    public int Id { get; set; }

    public int? AbsenceTypeId { get; set; }

    public int? WorkerId { get; set; }

    public int? WorkerInsteadId { get; set; }

    public DateTime? DateStart { get; set; }

    public DateTime? DateEnd { get; set; }

    public string? Reason { get; set; }

    public virtual AbsenceType? AbsenceType { get; set; }

    public virtual Worker? Worker { get; set; }

    public virtual Worker? WorkerInstead { get; set; }
}
