using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using GSRS.Api.Dtos;
using GSRS.Service.Models;

namespace GSRS.Demo.Infrastructure.Dtos
{

    public class ModContractDto : BaseDto
    {
        [Required]
        public int AgreementId { get; set; }
        [Required]

        public DateTime DateStart { get; set; }
        [Required]

        public DateTime DateEnd { get; set; }
        [Required]

        public double ContractValue { get; set; }

        public string? Comment { get; set; }
        public string? AgreementCode_Agreement { get; set; }

    }
}