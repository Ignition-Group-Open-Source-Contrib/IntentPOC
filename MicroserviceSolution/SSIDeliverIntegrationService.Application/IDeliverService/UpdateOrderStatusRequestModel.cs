using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Contracts.Clients.DtoContract", Version = "1.0")]

namespace SSIDeliverIntegrationService.Application.IDeliverService
{
    public class UpdateOrderStatusRequestModel
    {
        public static UpdateOrderStatusRequestModel Create(
            int status)
        {
            return new UpdateOrderStatusRequestModel
            {
                Status = status,
            };
        }

        public int Status { get; set; }
    }
}