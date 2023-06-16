using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using GSRS.Api.Dtos;

namespace GSRS.Demo.Infrastructure.Dtos
{

    public class AgreementDto : BaseDto
    {
        [Required]
        public string AgreementCode { get; set; } = null!;
        [Required]
        public int VendorId { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public string MacProjectNo { get; set; } = null!;
        [Required]
        public string InitialsResponsible { get; set; } = null!;
        [Required]
        public bool? Enabled { get; set; }
        [Required]
        public string? MackTaskName_nondk { get; set; }
        [Required]
        public string? MacPostingAccount { get; set; }
        [Required]
        public bool IsGlobal { get; set; }
        [Required]
        public int? WarningThresholdInDays { get; set; }
        [Required]
        public string? MacTaskName_LIC { get; set; }

        public string? Comment { get; set; }
        // [Required]
        public string? LocalCountryIso { get; set; }
        [Required]
        public string? FinanceResponsible { get; set; }
        // [Required]
        public string? MacIncomeDepartment { get; set; }

        public string? VendorName { get; set; } = null!;   //foreign key

    }
}
