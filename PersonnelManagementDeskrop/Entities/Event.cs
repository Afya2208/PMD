using System;
using System.Collections.Generic;

namespace PersonnelManagementDeskrop.Entities;

public partial class Event
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? EventTypeId { get; set; }

    public string? Status { get; set; }

    public string? Place { get; set; }

    public DateTime? DateStart { get; set; }

    public DateTime? DateEnd { get; set; }

    public DateTime? DateCreated { get; set; }

    public int? AuthorId { get; set; }

    public string? Description { get; set; }

    public virtual Worker? Author { get; set; }

    public virtual EventType? EventType { get; set; }
}
