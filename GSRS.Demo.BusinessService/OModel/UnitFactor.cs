using System;
using System.Collections.Generic;
using GSRS.Service.Models;

namespace GSRS.Demo.BusinessService.Model;

public class UnitFactor : BaseModel
{
    public string UnitFactorCode { get; set; } = null!;

    public int UnitDefinitionId { get; set; }

    public string Description { get; set; } = null!;

    public double CostValue { get; set; }

    public virtual ICollection<ProductGroup> ProductGroups { get; } = new List<ProductGroup>();

    public virtual UnitDefinition UnitDefinition { get; set; } = null!;
}
