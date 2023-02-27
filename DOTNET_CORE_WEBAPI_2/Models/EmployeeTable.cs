using System;
using System.Collections.Generic;

namespace DOTNET_CORE_WEBAPI_2.Models;

public partial class EmployeeTable
{
    public int EmployeeId { get; set; }

    public string EmployeeName { get; set; } = null!;

    public string ContactNo { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string ZipCode { get; set; } = null!;

    public bool ActiveStatus { get; set; }

    public virtual ICollection<EducationalDetailsTable> EducationalDetailsTables { get; } = new List<EducationalDetailsTable>();
}
