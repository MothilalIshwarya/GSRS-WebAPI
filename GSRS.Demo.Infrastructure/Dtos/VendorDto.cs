using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using GSRS.Api.Dtos;

namespace GSRS.Demo.Infrastructure.Dtos
{
    public class VendorDto : BaseDto
    {
        // [Required]
        public string VendorCode { get; set; } = null!;
        // [Required]
        public string VendorName { get; set; } = null!;
        // [Required]
        public string? VendorAddress { get; set; }
    }
}
