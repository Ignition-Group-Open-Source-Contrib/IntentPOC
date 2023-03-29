using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace IDeliverService.Application
{

    public class CreateProductRequestModel
    {
        public CreateProductRequestModel()
        {
        }

        public static CreateProductRequestModel Create(
            string sku,
            string name,
            decimal price,
            decimal width,
            decimal length,
            decimal height,
            decimal weight,
            bool has_serial_numbers,
            int channel_id)
        {
            return new CreateProductRequestModel
            {
                Sku = sku,
                Name = name,
                Price = price,
                Width = width,
                Length = length,
                Height = height,
                Weight = weight,
                Has_serial_numbers = has_serial_numbers,
                Channel_id = channel_id,
            };
        }

        public string Sku { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public decimal Width { get; set; }

        public decimal Length { get; set; }

        public decimal Height { get; set; }

        public decimal Weight { get; set; }

        public bool Has_serial_numbers { get; set; }

        public int Channel_id { get; set; }

    }
}