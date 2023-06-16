using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using GSRS.Api.Dtos;
using GSRS.Service.Models;

namespace GSRS.Demo.Infrastructure.Dtos
{

    public class ProductGroupPriceDto : BaseDto
    {
        [Required]
        public int ProductGroupId { get; set; }

        public int LicServerGroupId { get; set; }

        [Required]
        public DateTime? DateStart { get; set; }

        [Required]
        public DateTime? DateEnd { get; set; }

        [Required]
        public float? PriceContract { get; set; }

        public float? PricePerUnit { get; set; }

        public float CostFactor { get; set; }

        public bool? Enabled { get; set; }

        public string? MacComment { get; set; }

        public string? Description { get; set; }

        public string? ProductGroupName { get; set; } //foreign data

        public string? ServerGroupName { get; set; } //foreign data

    }
}
