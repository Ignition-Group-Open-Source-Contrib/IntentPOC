using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;
using static SSIDeliverIntegrationService.Application.Common.Enum.Enumerator;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace SSIDeliverIntegrationService.Application.ViewModels
{

    public class CommsState
    {
        public CommsState()
        {
        }

        public static CommsState Create(
            int id,
            int commsType,
            ActionTypeEnum actionType)
        {
            return new CommsState
            {
                Id = id,
                CommsType = commsType,
                ActionType = actionType,
            };
        }

        public int Id { get; set; }

        public int CommsType { get; set; }

        public ActionTypeEnum ActionType { get; set; }

    }
}