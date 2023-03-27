using System;
using System.Collections.Generic;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.DtoModel", Version = "1.0")]

namespace SSIDeliverIntegrationService.Application.ViewModels
{

    public class ExceptionErrorMessage
    {
        public ExceptionErrorMessage()
        {
        }

        public static ExceptionErrorMessage Create(
            string exceptionMessage)
        {
            return new ExceptionErrorMessage
            {
                ExceptionMessage = exceptionMessage,
            };
        }

        public string ExceptionMessage { get; set; }

    }
}