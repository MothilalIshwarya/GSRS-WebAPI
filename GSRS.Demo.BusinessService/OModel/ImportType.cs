using System;
using System.Collections.Generic;
using GSRS.Service.Models;

namespace GSRS.Demo.BusinessService.Model;

public class ImportType : BaseModel
{
    public string? ImportTypeName { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<LicenseType> LicenseTypes { get; } = new List<LicenseType>();
}
