using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using GSRS.Api.Dtos;
using GSRS.Service.Models;

namespace GSRS.Demo.Infrastructure.Dtos
{

    public class UnitDefinitionDto : BaseDto
    {
        [Required]
        public string UnitDefinitionCode { get; set; } = null!;

        [Required]
        public string? Description { get; set; }

        [Required]
        public string? ShortDescription { get; set; }

        [Required]
        public string? UsageTip { get; set; }

    }
}
