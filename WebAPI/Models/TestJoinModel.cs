using DataAccess.Models;

namespace WebAPI.Models
{
    public class TestJoinModel
    {
        public string VehicleName { get; set; }
        public string VehicleOwnerName { get; set; }
        public int EstimateNo { get; set; }
        public int Premium { get; set; }
    }
}
