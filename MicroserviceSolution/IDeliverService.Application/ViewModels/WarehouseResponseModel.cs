using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace IDeliverService.Application.ViewModels
{

    public class WarehouseResponseModel
    {
        public WarehouseResponseModel()
        {
        }

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