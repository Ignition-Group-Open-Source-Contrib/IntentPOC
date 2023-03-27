using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace SSIDeliverIntgnService.Application.Orders
{

    public class CreateOrderIDeliverOrderInfoDto
    {
        public CreateOrderIDeliverOrderInfoDto()
        {
        }

        public static CreateOrderIDeliverOrderInfoDto Create(
            int? createdByUSerId,
            int? updatedByUserId,
            DateTime? createdOnDate,
            DateTime? updatedOnDate,
            int courierId)
        {
            return new CreateOrderIDeliverOrderInfoDto
            {
                CreatedByUSerId = createdByUSerId,
                UpdatedByUserId = updatedByUserId,
                CreatedOnDate = createdOnDate,
                UpdatedOnDate = updatedOnDate,
                CourierId = courierId,
            };
        }

        public int? CreatedByUSerId { get; set; }

        public int? UpdatedByUserId { get; set; }

        public DateTime? CreatedOnDate { get; set; }

        public DateTime? UpdatedOnDate { get; set; }

        public int CourierId { get; set; }

    }
}