using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using GSRS.Api.Dtos;
using GSRS.Service.Models;

namespace GSRS.Demo.Infrastructure.Dtos
{

    public class ProductGroupDto : BaseDto
    {
        [Required]
        public int AgreementId { get; set; }
        [Required]
        public int UnitFactorId { get; set; }
        [Required]
        public string? ProductGroupCode { get; set; }
        [Required]
        public string? ProductGroupName { get; set; }
        [Required]
        public int? CostModelId { get; set; }
        [Required]
        public int? AccountByGroup { get; set; }
        public string? Comment { get; set; }
        [Required]
        public int? Enabled { get; set; }
        [Required]
        public int? Graceperiod { get; set; }
        [Required]
        public int? SupportgroupId { get; set; }

        public string? Description_Agreement { get; set; } = null!; //foreign data

        public string? Description_UnitFactor { get; set; } = null!; //foreign data

        public string? Description_CostModel { get; set; } //foreign data

    }
}
