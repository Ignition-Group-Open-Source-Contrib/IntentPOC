using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Contracts.Clients.DtoContract", Version = "1.0")]

namespace SSIDeliverIntegrationService.Application.IDeliverService
{
    public class UpdateProductRequestModel
    {
        public static UpdateProductRequestModel Create(
            string name,
            decimal price,
            decimal width,
            decimal length,
            decimal height,
            decimal weight,
            bool has_serial_numbers)
        {
            return new UpdateProductRequestModel
            {
                Name = name,
                Price = price,
                Width = width,
                Length = length,
                Height = height,
                Weight = weight,
                Has_serial_numbers = has_serial_numbers,
            };
        }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public decimal Width { get; set; }

        public decimal Length { get; set; }

        public decimal Height { get; set; }

        public decimal Weight { get; set; }

        public bool Has_serial_numbers { get; set; }
    }
}