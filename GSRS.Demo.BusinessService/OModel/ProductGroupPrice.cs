using System;
using System.Collections.Generic;
using GSRS.Service.Models;

namespace GSRS.Demo.BusinessService.Model;

public class ProductGroupPrice : BaseModel
{
    public int ProductGroupId { get; set; }

    public int LicServerGroupId { get; set; }

    public DateTime? DateStart { get; set; }

    public DateTime? DateEnd { get; set; }

    public float? PriceContract { get; set; }

    public float? PricePerUnit { get; set; }

    public float CostFactor { get; set; }

    public bool? Enabled { get; set; }

    public string? MacComment { get; set; }

    public string? Description { get; set; }

    public virtual LicenseServerGroup LicServerGroup { get; set; } = null!;

    public virtual ProductGroup ProductGroup { get; set; } = null!;
}
