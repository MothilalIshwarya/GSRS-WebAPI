using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using GSRS.Api.Dtos;
using GSRS.Service.Models;

namespace GSRS.Demo.Infrastructure.Dtos
{

    public class ImportTypeDto : BaseDto
    {
        [Required]
        public string? ImportTypeName { get; set; }

        [Required]
        public string? Description { get; set; }

    }
}


