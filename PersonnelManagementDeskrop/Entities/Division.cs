using System;
using System.Collections.Generic;

namespace PersonnelManagementDeskrop.Entities;

public partial class Division
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? HeadDivisionId { get; set; }

    public string? Description { get; set; }

    public int? HeadWorkerId { get; set; }

    public virtual Division? HeadDivision { get; set; }

    public virtual Worker? HeadWorker { get; set; }

    public virtual ICollection<Division> InverseHeadDivision { get; set; } = new List<Division>();

    public virtual ICollection<Worker> Workers { get; set; } = new List<Worker>();
}
