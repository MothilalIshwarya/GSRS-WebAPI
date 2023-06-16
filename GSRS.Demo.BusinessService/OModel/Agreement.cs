using System;
using System.Collections.Generic;
using GSRS.Service.Models;

namespace GSRS.Demo.BusinessService.Model;

public class Agreement : BaseModel
{
    public string AgreementCode { get; set; } = null!;

    public int VendorId { get; set; }

    public string? Description { get; set; }

    public string MacProjectNo { get; set; } = null!;

    public string InitialsResponsible { get; set; } = null!;

    public bool? Enabled { get; set; }

    public string? MackTaskName_nondk { get; set; }

    public string? MacPostingAccount { get; set; }

    public bool IsGlobal { get; set; }

    public int? WarningThresholdInDays { get; set; }

    public string? MacTaskName_LIC { get; set; }

    public string? Comment { get; set; }

    public string? LocalCountryIso { get; set; }

    public string? FinanceResponsible { get; set; }

    public string? MacIncomeDepartment { get; set; }

    public virtual ICollection<ProductGroup> ProductGroups { get; } = new List<ProductGroup>();

    public virtual Vendor Vendor { get; set; } = null!;
}
