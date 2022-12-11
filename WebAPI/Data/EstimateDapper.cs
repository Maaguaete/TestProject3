
using Dapper;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class EstimateDapper
    {
        private static EstimateDapper? _dbDapper;
        public static EstimateDapper Instance
        {
            get { return _dbDapper ??= new EstimateDapper(); }
        }

        //public double GetEstimate(EstimateModel model)
        //{
        //    double premium = 0;
        //    try
        //    {
        //        Connection.Instance.Get().Open();
        //        string sql = "SELECT Annually FROM Policy WHERE PolicyType = @Type";
        //        long annually = Connection.Instance.Get().Query<long>(sql, new
        //        {
        //            Type = model.PolicyType
        //        }).FirstOrDefault();
        //        premium += annually;
                

        //        if (model.Seats > 4)
        //        {
        //            premium += 0.05 * model.VehicleRate;
        //        }
        //        premium += GetRateOnPrice(model.VehicleRate) * model.VehicleRate;
        //        premium += GetRateOnVersion(model.VehicleVersion) * model.VehicleRate;
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    finally
        //    {
        //        Connection.Instance.Get().Close();
        //    }
        //    return premium;
        //}
        //double GetRateOnPrice(int vehicleRate)
        //{

        //    if (vehicleRate > 70000)
        //    {
        //        return 0.015;
        //    }
        //    else if (vehicleRate > 50000)
        //    {
        //        return 0.012;
        //    }
        //    else if (vehicleRate > 30000)
        //    {
        //        return 0.01;
        //    }
        //    return 0;
        //}
        //double GetRateOnVersion(string verion)
        //{
        //    int thisYear = System.DateTime.Now.Year;

        //    switch (thisYear - Int16.Parse(verion))
        //    {
        //        case 0:
        //        case 1:
        //            return 0;
        //            break;
        //        case 2:
        //        case 3:
        //            return 0.015;
        //            break;
        //        case 4:
        //        case 5:
        //            return 0.016;
        //            break;
        //        case 6:
        //        case 7:
        //        case 8:
        //        case 9:
        //            return 0.0175;
        //            break;
        //        default:
        //            return 0.019;
        //            break;
        //    }
        //}
    }
}
