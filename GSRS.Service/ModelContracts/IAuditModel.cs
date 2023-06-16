using System;

namespace GSRS.Service.ModelContracts
{
    public interface IAuditModel
    {
        DateTime? DateCreated { get; set; }
        DateTime? DateChanged { get; set; }
        string? ChangedBy { get; set; }
    }
}