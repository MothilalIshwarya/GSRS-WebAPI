using System;
using System.Collections.Generic;
using GSRS.Api.Dtos;
using GSRS.Service.Models;

namespace GSRS.Demo.Infrastructure.Dtos
{

    public class AutoImportTypeDto : BaseDto
    {
        public string? AutoImportCode { get; set; }

        public string? Description { get; set; }
    }
}
