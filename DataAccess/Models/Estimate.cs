using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Estimate
{
    public int Id { get; set; }

    public int EstimateNo { get; set; }

    public long? CustomerId { get; set; }

    public int? VehicleId { get; set; }

    public string VehicleWarranty { get; set; } = null!;

    public int VehiclePolicyId { get; set; }

    public int Premium { get; set; }

    public virtual Policy VehiclePolicy { get; set; } = null!;
}
