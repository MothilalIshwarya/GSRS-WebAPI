using System;
using System.Collections.Generic;
using GSRS.Service.Models;

namespace GSRS.Demo.BusinessService.Model;

public class AutoImportType : BaseModel
{
    public string? AutoImportCode { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<LicenseServer> LicenseServers { get; } = new List<LicenseServer>();
}
