using System;
using System.Collections.Generic;
using GSRS.Service.Models;

namespace GSRS.Demo.BusinessService.Model;

public class UnitDefinition : BaseModel
{
    public string UnitDefinitionCode { get; set; } = null!;

    public string? Description { get; set; }

    public string? ShortDescription { get; set; }

    public string? UsageTip { get; set; }

    public virtual ICollection<UnitFactor> UnitFactors { get; } = new List<UnitFactor>();
}
