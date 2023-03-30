using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Contracts.Clients.DtoContract", Version = "1.0")]

namespace SSIDeliverIntegrationService.Application.IDeliverService
{
    public class WarehouseResponseModel
    {
        public static WarehouseResponseModel Create(
            int id,
            string name)
        {
            return new WarehouseResponseModel
            {
                Id = id,
                Name = name,
            };
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}