using System;
using System.Collections.Generic;

namespace DOTNET_CORE_WEBAPI_2.Models;

public partial class EducationalDetailsTable
{
    public int EducationalDetailsId { get; set; }

    public int EmployeeId { get; set; }

    public string Education { get; set; } = null!;

    public string? University { get; set; }

    public string GradeObtained { get; set; } = null!;

    public string PassingYear { get; set; } = null!;

    public bool? ActiveStatus { get; set; }

    public virtual EmployeeTable Employee { get; set; } = null!;
}
