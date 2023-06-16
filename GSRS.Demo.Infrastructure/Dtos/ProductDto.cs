using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using GSRS.Api.Dtos;
using GSRS.Service.Models;

namespace GSRS.Demo.Infrastructure.Dtos
{

    public class ProductDto : BaseDto
    {
        [Required]
        public int? ProductGroupId { get; set; }
        [Required]
        public string? FeaturesKey { get; set; }
        [Required]
        public int? LicTypeId { get; set; }
        [Required]
        public int? Enabled { get; set; }
        [Required]
        public int IsApproved { get; set; }
        [Required]
        public string? DisplayName { get; set; }
        [Required]
        public int? LicenseCount { get; set; }
        [Required]
        public string? ManufacturerName { get; set; }

        public string? Comment { get; set; }

        public string? ProductGroupName { get; set; } //Foreign data

        public string? LicTypeName { get; set; } //Foreign data
    }
}
