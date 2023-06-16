namespace GSRS.Service.ModelContracts
{
    public interface IBaseModel : IAuditModel
    {
        int Id { get; set; }
    }
}