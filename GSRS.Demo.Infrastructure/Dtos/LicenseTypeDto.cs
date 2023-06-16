using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GSRS.Api.Dtos;
using GSRS.Service.Models;

namespace GSRS.Demo.Infrastructure.Dtos
{
    public class LicenseTypeDto : BaseDto
    {
        [DataMember]
        public string? LicTypeName { get; set; }

        [DataMember]
        public int? ImportTypeId { get; set; }

        [DataMember]
        public int? Enabled { get; set; }

        [DataMember]
        public int? StatUserDay { get; set; }

        [DataMember]
        public int? StatHours { get; set; }

        [DataMember]
        public int? StatConcurrentUsers { get; set; }

        [DataMember]
        public string? ImportFrequency { get; set; }
        
        public string? ImportTypeName { get; set; } //foreign data
    }
}
