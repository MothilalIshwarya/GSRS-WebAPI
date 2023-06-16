using System;
using System.Collections.Generic;
using GSRS.Service.Models;

namespace GSRS.Demo.BusinessService.Model;

public class Vendor : BaseModel
{
    public string VendorCode { get; set; } = null!;

    public string VendorName { get; set; } = null!;

    public string? VendorAddress { get; set; }

    public virtual ICollection<Agreement> Agreements { get; } = new List<Agreement>();
}
