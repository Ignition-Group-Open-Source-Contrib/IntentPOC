using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace SSIDeliverIntgnService.Application.Orders
{

    public class CreateOrderOrderItemOrderStatusHistoryDto
    {
        public CreateOrderOrderItemOrderStatusHistoryDto()
        {
        }

        public static CreateOrderOrderItemOrderStatusHistoryDto Create(
            DateTime occured,
            string annotation,
            int? cancelStatusDetailId,
            int? eMOrderStatusHistoryId,
            int? mSOrderStatusHistoryId,
            int orderStatusDetailId,
            int emailCommSentStatusId,
            int smscommsSentStatusId)
        {
            return new CreateOrderOrderItemOrderStatusHistoryDto
            {
                Occured = occured,
                Annotation = annotation,
                CancelStatusDetailId = cancelStatusDetailId,
                EMOrderStatusHistoryId = eMOrderStatusHistoryId,
                MSOrderStatusHistoryId = mSOrderStatusHistoryId,
                OrderStatusDetailId = orderStatusDetailId,
                EmailCommSentStatusId = emailCommSentStatusId,
                SmscommsSentStatusId = smscommsSentStatusId,
            };
        }

        public DateTime Occured { get; set; }

        public string Annotation { get; set; }

        public int? CancelStatusDetailId { get; set; }

        public int? EMOrderStatusHistoryId { get; set; }

        public int? MSOrderStatusHistoryId { get; set; }

        public int OrderStatusDetailId { get; set; }

        public int EmailCommSentStatusId { get; set; }

        public int SmscommsSentStatusId { get; set; }

    }
}