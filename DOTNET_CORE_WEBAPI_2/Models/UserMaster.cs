using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;


namespace DOTNET_CORE_WEBAPI_2.Models;

public partial class UserMaster
{
    public int UserId { get; set; }

    [Required]
    public string UserName { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public DateTime? LastLoginDateTime { get; set; }

    public bool ActiveStatus { get; set; }
}
