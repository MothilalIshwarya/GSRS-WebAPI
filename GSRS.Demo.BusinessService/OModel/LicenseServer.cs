using System;
using System.Collections.Generic;
using GSRS.Service.Models;

namespace GSRS.Demo.BusinessService.Model;

public class LicenseServer : BaseModel
{
    public int? LicServerGroupId { get; set; }

    public int? LicTypeId { get; set; }

    public int? Enabled { get; set; }

    public int? AutoImportTypeId { get; set; }

    public string? FolderName { get; set; }

    public string? UdlFileName { get; set; }

    public string? Descriptions { get; set; }

    public int? DeltaPeakDays { get; set; }

    public int? EnabledPeak { get; set; }

    public double? DeltaTimeZoneHours { get; set; }

    public string? Country { get; set; }

    public bool HasDayLightSaving { get; set; }

    public string? Comment { get; set; }

    public string ServerName { get; set; } = null!;

    public virtual AutoImportType? AutoImportType { get; set; }

    public virtual LicenseServerGroup? LicServerGroup { get; set; }

    public virtual LicenseType? LicType { get; set; }
}
