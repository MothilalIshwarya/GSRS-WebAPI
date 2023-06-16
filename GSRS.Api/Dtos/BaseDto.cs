using System.Runtime.Serialization;
using GSRS.Api.DtoContracts;

namespace GSRS.Api.Dtos
{
    [DataContract]
    public class BaseDto : IBaseDto 
    {
        [DataMember]
        public int Id { get; set; }

        #region Audit Values
        [DataMember]
        public DateTime? DateCreated { get; set; }
        [DataMember]
        public DateTime? DateChanged { get; set; }
        [DataMember]
        public string? ChangedBy { get; set; }
        #endregion
    }
}
