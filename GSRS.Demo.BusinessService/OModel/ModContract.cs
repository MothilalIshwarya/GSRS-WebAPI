using System;
using System.Collections.Generic;
using GSRS.Service.Models;

namespace GSRS.Demo.BusinessService.Model;

public  class ModContract : BaseModel
{

    public int AgreementId { get; set; }

    public DateTime DateStart { get; set; }

    public DateTime DateEnd { get; set; }

    public double ContractValue { get; set; }

    public string? Comment { get; set; }

    public virtual Agreement Agreement { get; set; } = null!;
}
