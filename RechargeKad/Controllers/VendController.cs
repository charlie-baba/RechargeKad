using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RechargeKad.Config;
using RechargeKad.Enums;
using RechargeKad.Poco;
using RechargeKad.Model;
using RechargeKad.Service;
using RechargeKad.Util;
using Microsoft.Extensions.Logging;
using System;

namespace RechargeKad.Controllers
{
    [Produces("application/json")]
    [Route("api/kad1/vend")]
    public class VendController : Controller
    {
        private readonly RechargeKadDBContext _context;
        private readonly CreditSwitchConfig _config;
        private readonly ILogger _logger;
        
        public VendController(RechargeKadDBContext context, IOptions<CreditSwitchConfig> config, ILogger<VendController> logger)
        {
            _context = context;
            _config = config?.Value;
            _logger = logger;
        }

        // GET: api/kad1/vend
        [HttpGet]
        public IActionResult GetVend()
        {
            return Ok("Good to go");
        }

        // POST: api/Airtime
        [HttpPost]
        public async Task<IActionResult> PostTransaction([FromBody] VendRequest req)
        {
            _logger.LogInformation($"{req?.RechargeType} purchase request for {req?.PhoneNumber} NGN{req?.Amount}");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //persist request
            var rechargeType = req.RechargeType.ParseEnum<RechargeType>();
            var serviceCode = await _context.ServiceCodes.FirstOrDefaultAsync(x => x.RechargeType == rechargeType && 
                                                                                   x.NetworkType == req.NetworkType.ParseEnum<NetworkType>());
            var reqTrans = TransactionService.GetTransaction(req, rechargeType, serviceCode?.Code);
            _context.RechargeTransactions.Add(reqTrans);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Transaction request persisted.");

            //initate service call
            var switchReq = CreditSwitchService.GetRequest(reqTrans, _config);
            CreditSwitchRespose switchResp = null;
            try
            {
                switchResp = await RestHandler.PostJsonAsync<CreditSwitchRespose>(_config.BaseUrl, _config.AirtimePath, switchReq);
                if (switchResp == null)
                {
                    _logger.LogWarning("Switch response is null");
                    return BadRequest(TransactionService.GetFailureResponse(req));
                }
            } catch(Exception e)
            {
                _logger.LogError(e, "Web service request failed.");
                return BadRequest(TransactionService.GetFailureResponse(req));
            }
            
            //persist response
            var respTrans = TransactionService.GetTransaction(switchResp, switchReq, rechargeType);
            _context.RechargeTransactions.Add(respTrans);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Response transaction was persisted successfully.");

            var resp = TransactionService.GetResponse(switchResp, switchReq, req.DealerCode, null);
            return Ok(resp);
        }

    }
}