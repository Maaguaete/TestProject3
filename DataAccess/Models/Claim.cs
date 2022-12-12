using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Claim
{
    public int Id { get; set; }

    public int ClaimNumber { get; set; }

    public int CertificateId { get; set; }

    public string PolicyStartDate { get; set; } = null!;

    public string PolicyEndDate { get; set; } = null!;

    public string CustomerName { get; set; } = null!;

    public string PlaceOfAccident { get; set; } = null!;

    public string DateOfAccident { get; set; } = null!;

    public int InsuredAmount { get; set; }

    public int ClaimableAmount { get; set; }

    public virtual Certificate Certificate { get; set; } = null!;
}
