using System;
using System.Collections.Generic;

namespace PersonnelManagementDeskrop.Entities;

public partial class AbsenceType
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<WorkerAbsence> WorkerAbsences { get; set; } = new List<WorkerAbsence>();
}
