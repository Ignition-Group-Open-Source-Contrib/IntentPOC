using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebhookService.Application.Common.Helper;

namespace WebhookService.Application.Common.BusinessLogic
{
    public class WebHookFacade : IWebHookFacade
    {
        public (IDeliverRTSCallBackRequest, string) ValidateDeliveryRTSRequest(Dictionary<string, object> request)
        {
            //check the request parameter has correct key name
            if (!request.ContainsKey(Constants.IDELIVER_COLUMN_IDELIVERORDERID))
            {
                return (null, "Please pass correct key name as IDeliverOrderId");
            }

            int ideliverOrderId = 0;
            if (!int.TryParse(request.GetValueOrDefault(Constants.IDELIVER_COLUMN_IDELIVERORDERID).ToString(), out ideliverOrderId))
            {
                return (null, "Please pass IDeliverOrderId value");
            }

            if (!request.ContainsKey(Constants.IDELIVER_COLUMN_ORDERDETAILS))
            {
                return (null, "Please pass correct key name as RTS OrderDetails");
            }

            if (string.IsNullOrEmpty(request.GetValueOrDefault(Constants.IDELIVER_COLUMN_ORDERDETAILS).ToString()))
            {
                return (null, "Please pass RTS OrderDetails values");
            }

            var orderDetails = JsonConvert.DeserializeObject<List<ReturnOrderDetail>>(request.GetValueOrDefault(Constants.IDELIVER_COLUMN_ORDERDETAILS).ToString());
            if (orderDetails == null || !orderDetails.Any())
            {
                return (null, "Please pass RTS OrderDetails values");
            }

            StringBuilder errorMessage = new StringBuilder();
            foreach (var item in orderDetails)
            {
                //Check Order Reference of Order Detail
                if (string.IsNullOrEmpty(item.OrderRef))
                {               
                    errorMessage.AppendLine("Order Ref is mandatory.");
                }

            }

            var callBackRequest = new IDeliverRTSCallBackRequest
            {
                IDeliverOrderId = ideliverOrderId,
                OrderDetails = orderDetails
            };

            return (callBackRequest, errorMessage.ToString().Replace("\r\n", " ").Replace("\n", " ").Replace("\r", " "));
        }

        public (IDeliverOrderCallBackAPIRequest, string) ValidateRequest(Dictionary<string, object> request)
        {
            try
            {
                //check the request parameter has correct key name
                if (!request.ContainsKey(Constants.IDELIVER_COLUMN_IDELIVERORDERID))
                {
                    return (null, "Please pass correct key name as IDeliverOrderId");
                }

                int ideliverOrderId = 0;
                if (!int.TryParse(request.GetValueOrDefault(Constants.IDELIVER_COLUMN_IDELIVERORDERID).ToString(), out ideliverOrderId))
                {
                    return (null, "Please pass IDeliverOrderId value");
                }

                if (!request.ContainsKey(Constants.IDELIVER_COLUMN_WAYBILLNUMBER))
                {
                    return (null, "Please pass WayBillNumber value");
                }

                if (string.IsNullOrEmpty(request.GetValueOrDefault(Constants.IDELIVER_COLUMN_WAYBILLNUMBER).ToString()))
                {
                    return (null, "Please pass WayBillNumber value");
                }

                if (!request.ContainsKey(Constants.IDELIVER_COLUMN_ORDERDETAILS))
                {
                    return (null, "Please pass correct key name as OrderDetails");
                }

                if (string.IsNullOrEmpty(request.GetValueOrDefault(Constants.IDELIVER_COLUMN_ORDERDETAILS).ToString()))
                {
                    return (null, "Please pass OrderDetails values");
                }

                var orderDetails = JsonConvert.DeserializeObject<List<OrderDetail>>(request.GetValueOrDefault(Constants.IDELIVER_COLUMN_ORDERDETAILS).ToString());
                if (orderDetails == null || !orderDetails.Any())
                {
                    return (null, "Please pass OrderDetails values");
                }

                StringBuilder errorMessage = new StringBuilder();
                foreach (var item in orderDetails)
                {
                    //Check Order Reference of Order Detail
                    if (string.IsNullOrEmpty(item.OrderRef))
                    {
                        errorMessage.AppendLine("Order Ref is mandatory.");
                    }

                    //Check IDeliver Product Id of Order Detail
                    if (item.IDeliverProductId <= 0)
                    {
                        errorMessage.AppendLine("Order Product Id is Invalid.");
                    }

                }

                var callBackRequest = new IDeliverOrderCallBackAPIRequest
                {
                    IDeliverOrderId = ideliverOrderId,
                    WayBillNumber = request.GetValueOrDefault(Constants.IDELIVER_COLUMN_WAYBILLNUMBER).ToString(),
                    OrderDetails = orderDetails,
                    SaleAgreement = request.ContainsKey(Constants.IDELIVER_COLUMN_SALEAGREEMENT) ? request.GetValueOrDefault(Constants.IDELIVER_COLUMN_SALEAGREEMENT).ToString() : string.Empty
                };

                return (callBackRequest, errorMessage.ToString().Replace("\r\n", " ").Replace("\n", " ").Replace("\r", " "));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
