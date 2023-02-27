using System;
using System.Collections.Generic;

namespace DOTNET_CORE_WEBAPI_2.Models;

public partial class ErrorLog1
{
    public int ErrorId { get; set; }

    public string? PageName { get; set; }

    public string? MethodName { get; set; }

    public string? ErrorMessage { get; set; }

    public string? StackTrace { get; set; }

    public DateTime? CreatedDateTime { get; set; }
}
