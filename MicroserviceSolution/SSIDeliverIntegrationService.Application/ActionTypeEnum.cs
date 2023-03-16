using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Application.Dtos.ContractEnumModel", Version = "1.0")]

namespace SSIDeliverIntegrationService.Application
{
    public enum ActionTypeEnum
    {
        None = 0,
        ForgotPassword = 1,
        Topup = 2,
        JobCard = 3
    }
}