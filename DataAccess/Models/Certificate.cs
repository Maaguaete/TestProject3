using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Certificate
{
    public int Id { get; set; }

    public int PolicyNo { get; set; }

    public int BillId { get; set; }

    public long CustomerId { get; set; }

    public int VehiclePolicyId { get; set; }

    public int VehicleNumber { get; set; }

    public string VehicleName { get; set; } = null!;

    public string VehicleOwnerName { get; set; } = null!;

    public string VehicleModel { get; set; } = null!;

    public int VehicleVersion { get; set; }

    public int VehicleRate { get; set; }

    public string VehicleBodyNumber { get; set; } = null!;

    public string VehicleEngineNumber { get; set; } = null!;

    public string PolicyDate { get; set; } = null!;

    public int PolicyDuration { get; set; }

    public string VehicleWarranty { get; set; } = null!;

    public string? Prove { get; set; }

    public virtual CustomerBill Bill { get; set; } = null!;

    public virtual ICollection<Claim> Claims { get; } = new List<Claim>();
}
