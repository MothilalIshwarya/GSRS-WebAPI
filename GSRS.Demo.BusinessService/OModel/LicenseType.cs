using System;
using System.Collections.Generic;
using GSRS.Service.Models;

namespace GSRS.Demo.BusinessService.Model;

public class LicenseType : BaseModel
{
    public string? LicTypeName { get; set; }

    public int? ImportTypeId { get; set; }

    public int? Enabled { get; set; }

    public int? StatUserDay { get; set; }

    public int? StatHours { get; set; }

    public int? StatConcurrentUsers { get; set; }

    public string? ImportFrequency { get; set; }

    public virtual ImportType? ImportType { get; set; }

    public virtual ICollection<LicenseServer> LicenseServers { get; } = new List<LicenseServer>();

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
