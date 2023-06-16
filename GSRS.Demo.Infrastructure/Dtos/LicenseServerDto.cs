using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GSRS.Api.Dtos;
using GSRS.Service.Models;

namespace GSRS.Demo.Infrastructure.Dtos
{
    public class LicenseServerDto : BaseDto
    {
        [Required]
        public int? LicServerGroupId { get; set; }
        [Required]

        public int? LicTypeId { get; set; }
        [Required]

        public int? Enabled { get; set; }
        [Required]

        public int? AutoImportTypeId { get; set; }
        [Required]

        public string? FolderName { get; set; }
        [Required]

        public string? UdlFileName { get; set; }
        [Required]

        public string? Descriptions { get; set; }
        [Required]

        public int? DeltaPeakDays { get; set; }
        [Required]

        public int? EnabledPeak { get; set; }
        [Required]

        public double? DeltaTimeZoneHours { get; set; }
        [Required]

        public string? Country { get; set; }
        [Required]

        public bool HasDayLightSaving { get; set; }

        public string? Comment { get; set; }
        [Required]

        public string ServerName { get; set; } = null!;
        public string? ServerGroupName { get; set; } //foreign data

        public string? LicTypeName { get; set; }  //foreign data

        public string? Description { get; set; }  //foreign data
    }
}
