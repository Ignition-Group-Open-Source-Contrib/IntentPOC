using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace IDeliverService.Application.ViewModels
{

    public class CreateProductResponseModel : CreateProductRequestModel
    {
        public CreateProductResponseModel()
        {
        }

        public static CreateProductResponseModel Create(
            int id,
            string channel_name,
            string created_at,
            string updated_at)
        {
            return new CreateProductResponseModel
            {
                Id = id,
                Channel_name = channel_name,
                Created_at = created_at,
                Updated_at = updated_at,
            };
        }

        public int Id { get; set; }

        public string Channel_name { get; set; }

        public string Created_at { get; set; }

        public string Updated_at { get; set; }

    }
}