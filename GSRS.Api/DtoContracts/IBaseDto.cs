namespace GSRS.Api.DtoContracts
{
    public interface IBaseDto : IAuditDto
    {
        int Id { get; set; }
    }
}