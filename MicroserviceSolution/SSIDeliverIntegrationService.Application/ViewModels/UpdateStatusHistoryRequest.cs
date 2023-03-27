using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace SSIDeliverIntegrationService.Application.ViewModels
{

    public class UpdateStatusHistoryRequest
    {
        public UpdateStatusHistoryRequest()
        {
        }

        public static UpdateStatusHistoryRequest Create(
            int orderItemId,
            int statusDetailId,
            string statusMessage,
            int? cancellationReasonStatusId,
            int relatedOrderItemId,
            int? userId)
        {
            return new UpdateStatusHistoryRequest
            {
                OrderItemId = orderItemId,
                StatusDetailId = statusDetailId,
                StatusMessage = statusMessage,
                CancellationReasonStatusId = cancellationReasonStatusId,
                RelatedOrderItemId = relatedOrderItemId,
                UserId = userId,
            };
        }

        public int OrderItemId { get; set; }

        public int StatusDetailId { get; set; }

        public string StatusMessage { get; set; }

        public int? CancellationReasonStatusId { get; set; }

        public int RelatedOrderItemId { get; set; }

        public int? UserId { get; set; }

    }
}