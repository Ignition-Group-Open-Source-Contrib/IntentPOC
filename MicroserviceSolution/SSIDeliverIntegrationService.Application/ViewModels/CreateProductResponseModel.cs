using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace SSIDeliverIntegrationService.Application.ViewModels
{

    public class CreateProductResponseModel : CreateProductRequestModel
    {
        public CreateProductResponseModel()
        {
        }

        public static CreateProductResponseModel Create(
            int id,
            string channelName,
            string createdAt,
            string updatedAt)
        {
            return new CreateProductResponseModel
            {
                Id = id,
                ChannelName = channelName,
                CreatedAt = createdAt,
                UpdatedAt = updatedAt,
            };
        }

        public int Id { get; set; }

        public string ChannelName { get; set; }

        public string CreatedAt { get; set; }

        public string UpdatedAt { get; set; }

    }
}