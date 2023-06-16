using System.Runtime.Serialization;
using GSRS.Service.ModelContracts;

namespace GSRS.Service.Models
{
    [DataContract]
    public class BaseModel : IBaseModel
    {
        public int Id { get; set; }

        #region Audit Values
        public DateTime? DateCreated { get; set; }
        public DateTime? DateChanged { get; set; }
        public string? ChangedBy { get; set; }
        #endregion
    }
}