using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;
using static SSIDeliverIntegrationService.Application.Common.Enum.Enumerator;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace SSIDeliverIntegrationService.Application.ViewModels
{

    public class ActorRaiseEventModel
    {
        public ActorRaiseEventModel()
        {
        }

        public static ActorRaiseEventModel Create(
            int orderItemId,
            HandlerEnum serviceFabricEvent)
        {
            return new ActorRaiseEventModel
            {
                OrderItemId = orderItemId,
                ServiceFabricEvent = serviceFabricEvent
            };
        }

        public int OrderItemId { get; set; }
        public HandlerEnum ServiceFabricEvent { get; set; }
    }
}