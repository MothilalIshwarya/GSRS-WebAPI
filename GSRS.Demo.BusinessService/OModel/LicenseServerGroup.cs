using System;
using System.Collections.Generic;
using GSRS.Service.Models;

namespace GSRS.Demo.BusinessService.Model;

public class LicenseServerGroup : BaseModel
{
    public string? ServerGroupName { get; set; }

    public string? CountryIso { get; set; }

    public virtual ICollection<LicenseServer> LicenseServers { get; } = new List<LicenseServer>();

    public virtual ICollection<ProductGroupPrice> ProductGroupPrices { get; } = new List<ProductGroupPrice>();
}
