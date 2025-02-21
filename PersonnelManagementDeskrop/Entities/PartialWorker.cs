using System.ComponentModel.DataAnnotations.Schema;

namespace PersonnelManagementDeskrop.Entities;

public partial class Worker
{
    [NotMapped]
    public string Color
    {
        get
        {
            if (DateFired == null) return "LightBlue";
            else return "LightGray";
        }
    }
}