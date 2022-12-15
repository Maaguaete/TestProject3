using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstimateController : ControllerBase
    {
        private readonly VehicleInsurancedb2Context _db;

        public EstimateController(VehicleInsurancedb2Context dbContext)
        {
            this._db = dbContext;
        }

        [HttpPost]
        public IActionResult Estimate(EstimateModel model)
        {
            double premium = 0;
            /// DbContext
            try
            {
                Policy policy = _db.Policies.Where(p => p.PolicyType.Equals(model.PolicyType)).FirstOrDefault()!;
                if (policy != null)
                {
                    premium += policy.Annually;
                }
                if (model.Seats > 4)
                {
                    premium += 0.05 * model.VehicleRate;
                }
                premium += GetRateOnPrice(model.VehicleRate) * model.VehicleRate;
                premium += GetRateOnVersion(model.VehicleVersion) * model.VehicleRate;
            }
            catch (ArgumentNullException ex)
            {

                throw;
            }

            /// Dapper:
            //try
            //{
            //    Connection.Instance.Get().Open();
            //    string sql = $"SELECT Annually FROM Policy WHERE PolicyType = '{model.PolicyType}'";
            //    premium += Connection.Instance.Get().Query<long>(sql).FirstOrDefault();
            //    Connection.Instance.Get().Close();

            //    if (model.Seats > 4)
            //    {
            //        premium += 0.05 * model.VehicleRate;
            //    }
            //    premium += GetRateOnPrice(model.VehicleRate) * model.VehicleRate;
            //    premium += GetRateOnVersion(model.VehicleVersion) * model.VehicleRate;
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
            //finally
            //{
            //    Connection.Instance.Get().Close();
            //}



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

            switch (thisYear - Int16.Parse(verion))
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
        [HttpGet]
        [Route("TestJoin")]
        public IActionResult TestJoin()
        {
            var data = (from est in _db.Estimates
                        join veh in _db.Vehicles on est.VehicleId equals veh.Id
                        select new TestJoinModel
                        {
                            VehicleName = veh.VehicleName,
                            VehicleOwnerName = veh.VehicleOwnerName,
                            EstimateNo = est.EstimateNo,
                            Premium = est.Premium
                        }
                        ).Take(1);
            return Ok(data);
        }
        [HttpGet]
        [Route("Certificates")]
        public IActionResult Certificates()
        {
            List<CertificateModel> certificates = new List<CertificateModel>();
            certificates = (from cer in _db.Certificates
                            join cusbill in _db.CustomerBills on cer.BillId equals cusbill.Id
                            join pol in _db.Policies on cer.VehiclePolicyId equals pol.Id
                            join cus in _db.Customers on cusbill.CustomerId equals cus.Id
                            //where cer.CustomerId == id
                            select new CertificateModel
                            {
                                Id = cer.Id,
                                PolicyNo = cer.PolicyNo,
                                PolicyType = pol.PolicyType,
                                BillNo = cusbill.BillNo,
                                Premium = cusbill.Amount,
                                CustomerName = cus.CustomerName,
                                CustomerAddress = cus.CustomerAddress!,
                                CustomerPhone = cus.CustomerPhone,
                                PolicyCoverage = pol.Coverage,
                                VehicleNumber = cer.VehicleNumber,
                                VehicleName = cer.VehicleName,
                                VehicleOwnerName = cer.VehicleOwnerName,
                                VehicleModel = cer.VehicleModel,
                                VehicleVersion = cer.VehicleVersion,
                                PolicyDate = cer.PolicyDate,
                                PolicyDuration = cer.PolicyDuration,
                                VehicleWarranty = cer.VehicleWarranty,
                                Prove = cer.Prove
                            }).ToList();
            return Ok(certificates);
        }
        [HttpGet]
        [Route("Certificate")]
        public IActionResult Certificate(long id)
        {
            CertificateModel cert = new CertificateModel();
            cert = (from cer in _db.Certificates
                    join cusbill in _db.CustomerBills on cer.BillId equals cusbill.Id
                    join pol in _db.Policies on cer.VehiclePolicyId equals pol.Id
                    join cus in _db.Customers on cusbill.CustomerId equals cus.Id
                    where cer.Id == id
                    select new CertificateModel
                    {
                        Id = cer.Id,
                        PolicyNo = cer.PolicyNo,
                        PolicyType = pol.PolicyType,
                        BillNo = cusbill.BillNo,
                        Premium = cusbill.Amount,
                        CustomerName = cus.CustomerName,
                        CustomerAddress = cus.CustomerAddress!,
                        CustomerPhone = cus.CustomerPhone,
                        PolicyCoverage = pol.Coverage,
                        VehicleNumber = cer.VehicleNumber,
                        VehicleName = cer.VehicleName,
                        VehicleOwnerName = cer.VehicleOwnerName,
                        VehicleModel = cer.VehicleModel,
                        VehicleVersion = cer.VehicleVersion,
                        PolicyDate = cer.PolicyDate,
                        PolicyDuration = cer.PolicyDuration,
                        VehicleWarranty = cer.VehicleWarranty,
                        Prove = cer.Prove
                    }).FirstOrDefault()!;
            return Ok(cert);
        }
    }

}
