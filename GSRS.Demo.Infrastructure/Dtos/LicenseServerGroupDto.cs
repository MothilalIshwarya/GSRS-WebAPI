using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GSRS.Api.Dtos;
using GSRS.Service.Models;

namespace GSRS.Demo.Infrastructure.Dtos
{

    public class LicenseServerGroupDto : BaseDto
    {
        [DataMember]
        public string? ServerGroupName { get; set; }

        [DataMember]
        public string? CountryIso { get; set; }

    }
}
