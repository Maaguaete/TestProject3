using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using WebAPI.Data;
using WebAPI.Models;
namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstimateController : ControllerBase
    {
        [HttpPost]
        public IActionResult Estimate(EstimateModel model)
        {
            double premium = 0;
            try
            {
                Connection.Instance.Get().Open();
                string sql = $"SELECT Annually FROM Policy WHERE PolicyType = '{model.PolicyType}'";
                premium += Connection.Instance.Get().Query<long>(sql).FirstOrDefault();
                Connection.Instance.Get().Close();

                if (model.Seats > 4)
                {
                    premium += 0.05 * model.VehicleRate;
                }
                premium += GetRateOnPrice(model.VehicleRate) * model.VehicleRate;
                premium += GetRateOnVersion(model.VehicleVersion) * model.VehicleRate;
            }
            catch (Exception)
            {

                throw;
            }
            
            return Ok(premium);
        }
        double GetRateOnPrice(int vehicleRate)
        {

            if (vehicleRate > 70000)
            {
                return 0.015;
            }
            else if (vehicleRate > 50000)
            {
                return 0.012;
            }
            else if (vehicleRate > 30000)
            {
                return 0.01;
            }
            return 0;
        }
        double GetRateOnVersion(string verion)
        {
            int thisYear = System.DateTime.Now.Year;

            switch(thisYear - Int16.Parse(verion))
            {
                case 0:
                case 1:
                    return 0;
                    break;
                case 2:
                case 3:
                    return 0.015;
                    break;
                case 4:
                case 5:
                    return 0.016;
                    break;
                case 6:
                case 7:
                case 8:
                case 9:
                    return 0.0175;
                    break;
                default:
                    return 0.019;
                    break;
            }
        }
    }
   
}
