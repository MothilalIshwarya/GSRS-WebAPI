using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GSRS.Service.Models;

namespace GSRS.Demo.BusinessService.Model;

public class CostModel : BaseModel
{
    [Required]
    public string? CostModelName { get; set; }
     [Required]
    public string? Description { get; set; }

    public virtual ICollection<ProductGroup> ProductGroups { get; } = new List<ProductGroup>();
}
