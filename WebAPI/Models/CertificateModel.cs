namespace WebAPI.Models
{
    public class CertificateModel
    {
        public int Id { get; set; }
        public int PolicyNo { get; set; }
        public string PolicyType { get; set; }
        public int BillNo { get; set; }
        public int Premium { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public long CustomerPhone { get; set; }
        public string PolicyCoverage { get; set; }
        public int VehicleNumber { get; set; }
        public string VehicleName { get; set; } = null!;
        public string VehicleOwnerName { get; set; } = null!;
        public string VehicleModel { get; set; } = null!;
        public int VehicleVersion { get; set; }
        public string PolicyDate { get; set; } = null!;
        public int PolicyDuration { get; set; }
        public string VehicleWarranty { get; set; } = null!;
        public string? Prove { get; set; }
    }
}
