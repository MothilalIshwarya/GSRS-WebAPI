using System;
using System.Collections.Generic;
using GSRS.Service.Models;

namespace GSRS.Demo.BusinessService.Model;

public class ProductGroup : BaseModel
{
    public int AgreementId { get; set; }

    public int UnitFactorId { get; set; }

    public string? ProductGroupCode { get; set; }

    public string? ProductGroupName { get; set; }

    public int? CostModelId { get; set; }

    public int? AccountByGroup { get; set; }

    public string? Comment { get; set; }

    public int? Enabled { get; set; }

    public int? Graceperiod { get; set; }

    public int? SupportgroupId { get; set; }

    public virtual Agreement Agreement { get; set; } = null!;

    public virtual CostModel? CostModel { get; set; }

    public virtual ICollection<ProductGroupPrice> ProductGroupPrices { get; } = new List<ProductGroupPrice>();

    public virtual ICollection<Product> Products { get; } = new List<Product>();

    public virtual UnitFactor UnitFactor { get; set; } = null!;
}
