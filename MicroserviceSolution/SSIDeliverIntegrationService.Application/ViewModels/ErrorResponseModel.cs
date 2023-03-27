using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace SSIDeliverIntegrationService.Application.ViewModels
{

    public class ErrorResponseModel
    {
        public ErrorResponseModel()
        {
        }

        public static ErrorResponseModel Create(
            ExceptionErrorMessage responseException)
        {
            return new ErrorResponseModel
            {
                ResponseException = responseException,
            };
        }

        public ExceptionErrorMessage ResponseException { get; set; }

    }
}