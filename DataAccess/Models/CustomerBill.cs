using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class CustomerBill
{
    public int Id { get; set; }

    public long CustomerId { get; set; }

    public int BillNo { get; set; }

    public int EstimateId { get; set; }

    public string CustomerAddProve { get; set; } = null!;

    public string Date { get; set; } = null!;

    public int Amount { get; set; }

    public virtual ICollection<Certificate> Certificates { get; } = new List<Certificate>();
}
