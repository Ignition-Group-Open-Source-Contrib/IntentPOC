using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace SSIDeliverIntgnService.Application.Orders
{

    public class UpdateOrderIDeliverOrderInfoDto
    {
        public UpdateOrderIDeliverOrderInfoDto()
        {
        }

        public static UpdateOrderIDeliverOrderInfoDto Create(
            int? iDeliverOrderStatusDetailId,
            int? createdByUSerId,
            int? updatedByUserId,
            DateTime? createdOnDate,
            DateTime? updatedOnDate,
            int courierId,
            Guid id)
        {
            return new UpdateOrderIDeliverOrderInfoDto
            {
                IDeliverOrderStatusDetailId = iDeliverOrderStatusDetailId,
                CreatedByUSerId = createdByUSerId,
                UpdatedByUserId = updatedByUserId,
                CreatedOnDate = createdOnDate,
                UpdatedOnDate = updatedOnDate,
                CourierId = courierId,
                Id = id,
            };
        }

        public int? IDeliverOrderStatusDetailId { get; set; }

        public int? CreatedByUSerId { get; set; }

        public int? UpdatedByUserId { get; set; }

        public DateTime? CreatedOnDate { get; set; }

        public DateTime? UpdatedOnDate { get; set; }

        public int CourierId { get; set; }

        public Guid Id { get; set; }

    }
}