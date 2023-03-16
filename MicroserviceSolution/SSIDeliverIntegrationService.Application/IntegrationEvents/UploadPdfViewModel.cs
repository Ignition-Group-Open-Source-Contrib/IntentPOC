using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Eventing.Contracts.IntegrationEventDto", Version = "1.0")]

namespace SSIDeliverIntegrationService.Eventing
{
    public class UploadPdfViewModel
    {
        public UploadPdfViewModel()
        {
        }

        public int IDeliverOrderId { get; set; }
        public string Base64Encoded { get; set; }
        public string FileName { get; set; }
        public string BlobContainerName { get; set; }
        public string FileType { get; set; }

        public static UploadPdfViewModel Create(int iDeliverOrderId, string base64Encoded, string fileName, string blobContainerName, string fileType)
        {
            return new UploadPdfViewModel
            {
                IDeliverOrderId = iDeliverOrderId,
                Base64Encoded = base64Encoded,
                FileName = fileName,
                BlobContainerName = blobContainerName,
                FileType = fileType,
            };
        }
    }
}