
namespace GSRS.Api.DtoContracts
{
    public interface IAuditDto
    {
        DateTime? DateCreated { get; set; }
        DateTime? DateChanged { get; set; }
        string? ChangedBy { get; set; }
    }
}