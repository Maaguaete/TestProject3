using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Vehicle
{
    public int Id { get; set; }

    public int VehicleNumber { get; set; }

    public string VehicleName { get; set; } = null!;

    public string VehicleOwnerName { get; set; } = null!;

    public string VehicleModel { get; set; } = null!;

    public int VehicleVersion { get; set; }

    public int VehicleRate { get; set; }

    public string VehicleBodyNumber { get; set; } = null!;

    public string VehicleEngineNumber { get; set; } = null!;
}
