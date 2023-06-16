using System;
using System.Collections.Generic;
using GSRS.Service.Models;

namespace GSRS.Demo.BusinessService.Model;

public class Product : BaseModel
{
    public int? ProductGroupId { get; set; }

    public string? FeaturesKey { get; set; }

    public int? LicTypeId { get; set; }

    public int? Enabled { get; set; }

    public int IsApproved { get; set; }

    public string? DisplayName { get; set; }

    public int? LicenseCount { get; set; }

    public string? ManufacturerName { get; set; }

    public string? Comment { get; set; }

    public virtual LicenseType? LicType { get; set; }

    public virtual ProductGroup? ProductGroup { get; set; }
}
