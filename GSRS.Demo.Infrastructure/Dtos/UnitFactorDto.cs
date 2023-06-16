using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using GSRS.Api.Dtos;
using GSRS.Service.Models;

namespace GSRS.Demo.Infrastructure.Dtos
{

    public class UnitFactorDto : BaseDto
    {
        [Required]
        public string UnitFactorCode { get; set; } = null!;

        [Required]
        public int UnitDefinitionId { get; set; }

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public double CostValue { get; set; }

        
        //public string? UnitDefinitionDescription { get; set; } //foreign data
        public string? Description_UnitDefinition { get; set; } //foreign data
    }
}
