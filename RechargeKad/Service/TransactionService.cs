using RechargeKad.Enums;
using RechargeKad.Poco;
using System;
using RechargeKad.Model;
using RechargeKad.Util;

namespace RechargeKad.Service
{
    public class TransactionService
    {
        public static RechargeTransaction GetTransaction(VendRequest request, RechargeType type, string serviceCode)
        {
            if (request == null)
            {
                return null;
            }

            RechargeTransaction transaction = new RechargeTransaction
            {
                Amount = request.Amount,
                DealerCode = request.DealerCode,
                PhoneNumber = request.PhoneNumber,
                RechargeType = type,
                RequestType = RequestType.Request,
                ServiceCode = serviceCode,
                Status = TransactionStatus.INITIATED,
                TransactionId = Utility.GetRequestId(),
                TransDate = DateTime.Now
            };
            return transaction;
        }

        public static RechargeTransaction GetTransaction(CreditSwitchRespose resp, CreditSwitchRequest req, RechargeType type)
        {
            if (resp == null)
            {
                return null;
            }

            RechargeTransaction transaction = new RechargeTransaction
            {
                Amount = Convert.ToDouble(resp.Amount == 0 ? req.Amount : resp.Amount),
                ResponseCode = resp.StatusCode,
                ResponseDescription = resp.StatusDescription,
                TransactionId = String.IsNullOrWhiteSpace(resp.MReference) ? req.RequestId : resp.MReference,
                Reference = resp.TranxReference,
                PhoneNumber = String.IsNullOrWhiteSpace(resp.Recipient) ? req.Recipient : resp.Recipient,
                ConfirmCode = resp.ConfirmCode,
                TransDate = resp.TranxDate,
                RechargeType = type,
                RequestType = RequestType.Response,
                Status = resp.StatusCode == "00" ? TransactionStatus.SUCCESSFUL : TransactionStatus.FAILED
            };
            return transaction;
        }

        public static VendResponse GetResponse(CreditSwitchRespose resp, CreditSwitchRequest req, string dealerCode, string message)
        {
            if (resp == null)
            {
                return null;
            }

            VendResponse response = new VendResponse
            {
                TransactionId = String.IsNullOrWhiteSpace(resp.MReference) ? req.RequestId : resp.MReference,
                PhoneNumber = String.IsNullOrWhiteSpace(resp.Recipient) ? req.Recipient : resp.Recipient,
                DealerCode = dealerCode,
                Amount = Convert.ToInt64(req.Amount),
                Success = resp.StatusCode == "00",
                ResponseCode = resp.StatusCode,
                ResponseMessage = message ?? resp.StatusDescription
            };
            return response;
        }

        public static VendResponse GetFailureResponse(VendRequest req)
        {
            VendResponse response = new VendResponse
            {
                DealerCode = req?.DealerCode,
                Amount = req == null ? 0 : req.Amount,
                Success = false,
                ResponseCode = "ZZ",
                ResponseMessage = $"Unable to complete your request. Please try again later."
            };
            return response;
        }
    }
}
