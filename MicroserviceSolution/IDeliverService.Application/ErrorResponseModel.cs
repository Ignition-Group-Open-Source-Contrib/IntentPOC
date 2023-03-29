using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace IDeliverService.Application
{

    public class ErrorResponseModel
    {
        public ErrorResponseModel()
        {
        }

        public static ErrorResponseModel Create(
            string message)
        {
            return new ErrorResponseModel
            {
                Message = message,
            };
        }

        public string Message { get; set; }

    }
}